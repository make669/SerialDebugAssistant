# src/orchestrator

The Orchestrator is the central workflow router for Sherlock.

Responsibilities:
- Receive user requests from the CLI / Web UI layer.
- Triage simple intents to the local small model (MiMo) for lightweight handling.
- Route complex, multi-step tasks to the Context Builder and downstream pipelines.
- Aggregate results from all pipelines and emit structured output artifacts.
