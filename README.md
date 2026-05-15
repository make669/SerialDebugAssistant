# Face Emotion Recognition System (Initial Framework)

This repository now includes an initial scaffold for a realtime face emotion recognition system with a Java backend, Vue 3 frontend, AI placeholder service, SQL Server schema, and Docker Compose stack.

## Architecture

- **Backend**: Spring Boot + WebFlux (`emotion-system/backend`)
  - Task management module (`task`)
  - Video/stream processing placeholder (`stream`)
  - OpenCV integration placeholder (`opencv`)
  - AI inference client placeholder (`ai`)
  - Fusion service (`fusion`)
  - Advice service (`advice`)
  - WebSocket endpoint (`ws`) at `/ws/emotion/{taskId}`
  - REST controllers (`task`, `api`)
  - Configuration-driven emotion types (`emotion.types` in `application.yml`)
- **Frontend**: Vue 3 + Vite (`emotion-system/frontend`)
  - Task management page placeholder (`/tasks`)
  - Realtime dashboard page placeholder (`/dashboard`)
- **AI Service**: FastAPI placeholder (`emotion-system/ai-service`)
- **Database**: SQL Server schema and seed scripts (`emotion-system/infra/sql/schema.sql`)
- **Container Orchestration**: Docker Compose (`emotion-system/docker-compose.yml`)

## Services in Docker Compose

- `api-service`: Spring Boot WebFlux API (port `8080`)
- `ai-service`: placeholder model service (port `5000`)
- `sqlserver`: SQL Server 2022 (port `1433`)
- `sql-init`: one-shot SQL schema bootstrap runner

Environment variables used:

- `MSSQL_SA_PASSWORD` (default: `YourStrong!Passw0rd`)
- `AI_SERVICE_BASE_URL` (set by compose to `http://ai-service:5000`)
- `SPRING_DATASOURCE_URL`, `SPRING_DATASOURCE_USERNAME`, `SPRING_DATASOURCE_PASSWORD`

## Run the Stack

```bash
cd emotion-system
docker compose up --build
```

## Local Development

### Backend

```bash
cd emotion-system/backend
mvn spring-boot:run
```

### Frontend

```bash
cd emotion-system/frontend
npm install
npm run dev
```

## Notes

- This is intentionally a minimal, buildable scaffold.
- AI model inference, FFmpeg streaming, and OpenCV runtime wiring are left as TODO placeholders for later integration.
