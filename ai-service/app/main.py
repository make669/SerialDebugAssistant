from fastapi import FastAPI
from pydantic import BaseModel

app = FastAPI(title="Emotion AI Service", version="0.1.0")


class InferenceRequest(BaseModel):
    task_id: str | None = None
    payload: str | None = None


class InferenceResponse(BaseModel):
    type: str
    emotion: str
    confidence: float


@app.get("/health")
def health() -> dict[str, str]:
    return {"status": "ok"}


@app.post("/infer/audio", response_model=InferenceResponse)
def infer_audio(_: InferenceRequest) -> InferenceResponse:
    return InferenceResponse(type="audio", emotion="neutral", confidence=0.5)


@app.post("/infer/face", response_model=InferenceResponse)
def infer_face(_: InferenceRequest) -> InferenceResponse:
    return InferenceResponse(type="face", emotion="neutral", confidence=0.5)


@app.post("/infer/micro", response_model=InferenceResponse)
def infer_micro(_: InferenceRequest) -> InferenceResponse:
    return InferenceResponse(type="micro", emotion="neutral", confidence=0.5)
