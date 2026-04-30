# src/agents

Individual agent implementations used within Sherlock pipelines.

- **DebateAgent** — participates in red/blue-team planning debates.
- **ReflectionAgent** — critiques and refines plans produced by DebateAgent.
- **CodeAgent** — implements the code → test → error → reflect → patch loop.
- **SummaryAgent** — performs hierarchical summarization with CoT / ToT.
