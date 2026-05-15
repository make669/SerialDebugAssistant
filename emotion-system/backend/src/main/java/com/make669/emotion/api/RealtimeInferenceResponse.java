package com.make669.emotion.api;

import com.make669.emotion.fusion.FusedEmotionResponse;

public record RealtimeInferenceResponse(long taskId, FusedEmotionResponse fused, String advice) {
}
