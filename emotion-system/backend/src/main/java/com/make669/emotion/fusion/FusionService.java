package com.make669.emotion.fusion;

import com.make669.emotion.ai.EmotionInferenceResult;
import java.util.Comparator;
import java.util.List;
import org.springframework.stereotype.Service;
import reactor.core.publisher.Mono;

@Service
public class FusionService {

    public Mono<FusedEmotionResponse> fuse(List<EmotionInferenceResult> signals) {
        EmotionInferenceResult strongest = signals.stream()
                .max(Comparator.comparingDouble(EmotionInferenceResult::confidence))
                .orElse(new EmotionInferenceResult("fusion", "neutral", 0.0d));

        return Mono.just(new FusedEmotionResponse(strongest.emotion(), strongest.confidence(), signals));
    }
}
