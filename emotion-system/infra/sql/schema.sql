IF DB_ID('emotiondb') IS NULL
BEGIN
    CREATE DATABASE emotiondb;
END;
GO

USE emotiondb;
GO

IF OBJECT_ID('dbo.emotion_type', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.emotion_type
    (
        emotion_type_id INT IDENTITY(1,1) PRIMARY KEY,
        code NVARCHAR(50) NOT NULL UNIQUE,
        display_name NVARCHAR(100) NOT NULL,
        is_enabled BIT NOT NULL CONSTRAINT DF_emotion_type_is_enabled DEFAULT (1),
        created_at DATETIME2 NOT NULL CONSTRAINT DF_emotion_type_created_at DEFAULT (SYSUTCDATETIME())
    );
END;
GO

IF OBJECT_ID('dbo.model_emotion_mapping', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.model_emotion_mapping
    (
        model_emotion_mapping_id INT IDENTITY(1,1) PRIMARY KEY,
        model_name NVARCHAR(100) NOT NULL,
        model_label NVARCHAR(100) NOT NULL,
        emotion_type_id INT NOT NULL,
        created_at DATETIME2 NOT NULL CONSTRAINT DF_model_emotion_mapping_created_at DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT FK_model_emotion_mapping_emotion_type FOREIGN KEY (emotion_type_id)
            REFERENCES dbo.emotion_type (emotion_type_id)
    );

    CREATE UNIQUE INDEX UX_model_emotion_mapping_model_label
        ON dbo.model_emotion_mapping (model_name, model_label);
END;
GO

IF OBJECT_ID('dbo.analysis_task', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.analysis_task
    (
        analysis_task_id BIGINT IDENTITY(1,1) PRIMARY KEY,
        stream_url NVARCHAR(512) NOT NULL,
        status NVARCHAR(30) NOT NULL,
        created_at DATETIME2 NOT NULL CONSTRAINT DF_analysis_task_created_at DEFAULT (SYSUTCDATETIME()),
        updated_at DATETIME2 NOT NULL CONSTRAINT DF_analysis_task_updated_at DEFAULT (SYSUTCDATETIME())
    );
END;
GO

IF OBJECT_ID('dbo.emotion_timeline', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.emotion_timeline
    (
        emotion_timeline_id BIGINT IDENTITY(1,1) PRIMARY KEY,
        analysis_task_id BIGINT NOT NULL,
        segment_start_at DATETIME2 NOT NULL,
        segment_end_at DATETIME2 NOT NULL,
        audio_emotion_type_id INT NULL,
        face_emotion_type_id INT NULL,
        micro_emotion_type_id INT NULL,
        final_emotion_type_id INT NOT NULL,
        final_confidence DECIMAL(5,4) NOT NULL,
        created_at DATETIME2 NOT NULL CONSTRAINT DF_emotion_timeline_created_at DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT FK_emotion_timeline_analysis_task FOREIGN KEY (analysis_task_id) REFERENCES dbo.analysis_task (analysis_task_id),
        CONSTRAINT FK_emotion_timeline_audio_emotion_type FOREIGN KEY (audio_emotion_type_id) REFERENCES dbo.emotion_type (emotion_type_id),
        CONSTRAINT FK_emotion_timeline_face_emotion_type FOREIGN KEY (face_emotion_type_id) REFERENCES dbo.emotion_type (emotion_type_id),
        CONSTRAINT FK_emotion_timeline_micro_emotion_type FOREIGN KEY (micro_emotion_type_id) REFERENCES dbo.emotion_type (emotion_type_id),
        CONSTRAINT FK_emotion_timeline_final_emotion_type FOREIGN KEY (final_emotion_type_id) REFERENCES dbo.emotion_type (emotion_type_id)
    );
END;
GO

IF OBJECT_ID('dbo.expert_advice', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.expert_advice
    (
        expert_advice_id BIGINT IDENTITY(1,1) PRIMARY KEY,
        analysis_task_id BIGINT NOT NULL,
        emotion_type_id INT NOT NULL,
        advice_text NVARCHAR(1000) NOT NULL,
        rule_code NVARCHAR(100) NULL,
        created_at DATETIME2 NOT NULL CONSTRAINT DF_expert_advice_created_at DEFAULT (SYSUTCDATETIME()),
        CONSTRAINT FK_expert_advice_analysis_task FOREIGN KEY (analysis_task_id) REFERENCES dbo.analysis_task (analysis_task_id),
        CONSTRAINT FK_expert_advice_emotion_type FOREIGN KEY (emotion_type_id) REFERENCES dbo.emotion_type (emotion_type_id)
    );
END;
GO

MERGE dbo.emotion_type AS target
USING (VALUES
    ('neutral', N'中性'),
    ('happy', N'高兴'),
    ('sad', N'悲伤'),
    ('angry', N'愤怒'),
    ('anxious', N'焦虑'),
    ('fear', N'害怕')
) AS source(code, display_name)
ON target.code = source.code
WHEN NOT MATCHED THEN
    INSERT (code, display_name) VALUES (source.code, source.display_name);
GO
