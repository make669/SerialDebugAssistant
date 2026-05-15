package com.make669.emotion.fusion;

import com.make669.emotion.ai.EmotionInferenceResult;
import java.util.List;

public record FusedEmotionResponse(String emotion, double confidence, List<EmotionInferenceResult> signals) {
}
