# src/memory

Long-term memory management using progressive summarization.

The memory system compresses conversation history and retrieved context
into rolling summaries so that the effective context window stays within
model limits while preserving salient information across sessions.
