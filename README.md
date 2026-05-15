# Real-time Emotion Recognition System (Framework)

This repository contains a multi-module project skeleton for a real-time emotion recognition system.

## Module order

1. `backend` — Java Spring Boot + WebFlux API with placeholder task management, WebSocket streaming, and AI inference client.
2. `ai-service` — Python FastAPI service with placeholder audio/face/micro inference endpoints.
3. `frontend` — Vue 3 (Vite) web UI with routing and a placeholder real-time dashboard view.
4. `docker-compose.yml` — Orchestration for `api-service`, `ai-service`, and `sqlserver`.

## Repository structure

```text
.
├── backend/
├── ai-service/
├── frontend/
└── docker-compose.yml
```

## Quick start

### Backend

```bash
cd backend
mvn clean package
mvn spring-boot:run
```

### AI service

```bash
cd ai-service
python -m venv .venv
source .venv/bin/activate
pip install -r requirements.txt
uvicorn app.main:app --reload
```

### Frontend

```bash
cd frontend
npm install
npm run dev
```

### Docker Compose

```bash
docker compose up --build
```

Services:
- API: `http://localhost:8080`
- AI service: `http://localhost:8000`
- SQL Server: `localhost:1433`
