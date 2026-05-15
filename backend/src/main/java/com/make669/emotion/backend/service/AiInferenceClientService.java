package com.make669.emotion.backend.service;

import com.make669.emotion.backend.dto.InferenceResponse;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Service;
import org.springframework.web.reactive.function.client.WebClient;
import reactor.core.publisher.Mono;

import java.util.Map;

@Service
public class AiInferenceClientService {

    private final WebClient webClient;

    public AiInferenceClientService(WebClient.Builder builder,
                                    @Value("${ai.service.base-url:http://ai-service:8000}") String baseUrl) {
        this.webClient = builder.baseUrl(baseUrl).build();
    }

    public Mono<InferenceResponse> inferAudio(Map<String, Object> payload) {
        return webClient.post()
                .uri("/infer/audio")
                .bodyValue(payload)
                .retrieve()
                .bodyToMono(InferenceResponse.class)
                .onErrorReturn(new InferenceResponse("audio", "placeholder", 0.0));
    }
}
