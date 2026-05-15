package com.make669.emotion.backend.controller;

import com.make669.emotion.backend.dto.InferenceResponse;
import com.make669.emotion.backend.service.AiInferenceClientService;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import reactor.core.publisher.Mono;

import java.util.Map;

@RestController
@RequestMapping("/api/inference")
public class InferenceController {

    private final AiInferenceClientService aiInferenceClientService;

    public InferenceController(AiInferenceClientService aiInferenceClientService) {
        this.aiInferenceClientService = aiInferenceClientService;
    }

    @PostMapping("/audio")
    public Mono<InferenceResponse> inferAudio(@RequestBody Map<String, Object> payload) {
        return aiInferenceClientService.inferAudio(payload);
    }
}
