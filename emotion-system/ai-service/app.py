from fastapi import FastAPI

app = FastAPI(title="emotion-ai-placeholder")


@app.get("/health")
def health() -> dict[str, str]:
    return {"status": "ok", "service": "ai-placeholder"}


@app.post("/infer/audio")
def infer_audio() -> dict[str, object]:
    return {"model": "audio-placeholder", "label": "neutral", "confidence": 0.5}


@app.post("/infer/face")
def infer_face() -> dict[str, object]:
    return {"model": "face-placeholder", "label": "neutral", "confidence": 0.5}


@app.post("/infer/micro")
def infer_micro() -> dict[str, object]:
    return {"model": "micro-placeholder", "label": "neutral", "confidence": 0.5}
