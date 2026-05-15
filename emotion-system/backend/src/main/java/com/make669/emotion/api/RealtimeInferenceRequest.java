package com.make669.emotion.api;

import jakarta.validation.constraints.Min;

public record RealtimeInferenceRequest(@Min(1) long taskId) {
}
