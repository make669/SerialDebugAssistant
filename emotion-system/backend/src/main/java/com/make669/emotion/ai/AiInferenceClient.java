package com.make669.emotion.ai;

import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Component;
import org.springframework.web.reactive.function.client.WebClient;
import reactor.core.publisher.Mono;

@Component
public class AiInferenceClient {

    private final WebClient webClient;

    public AiInferenceClient(WebClient.Builder builder, @Value("${app.ai-service.base-url}") String baseUrl) {
        this.webClient = builder.baseUrl(baseUrl).build();
    }

    public Mono<EmotionInferenceResult> inferAudio(long taskId) {
        return webClient.get()
                .uri("/health")
                .retrieve()
                .bodyToMono(String.class)
                .map(ignored -> new EmotionInferenceResult("audio", "neutral", 0.5d))
                .onErrorReturn(new EmotionInferenceResult("audio", "neutral", 0.0d));
    }

    public Mono<EmotionInferenceResult> inferFace(long taskId) {
        return Mono.just(new EmotionInferenceResult("face", "neutral", 0.5d));
    }

    public Mono<EmotionInferenceResult> inferMicroExpression(long taskId) {
        return Mono.just(new EmotionInferenceResult("micro", "neutral", 0.5d));
    }
}
