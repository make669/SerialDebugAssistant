package com.make669.emotion.api;

import com.make669.emotion.advice.AdviceService;
import com.make669.emotion.ai.AiInferenceClient;
import com.make669.emotion.config.EmotionTypeProperties;
import com.make669.emotion.fusion.FusedEmotionResponse;
import com.make669.emotion.fusion.FusionService;
import com.make669.emotion.opencv.OpenCvIntegrationService;
import com.make669.emotion.stream.VideoStreamService;
import jakarta.validation.Valid;
import java.util.List;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import reactor.core.publisher.Mono;

@RestController
@RequestMapping("/api/realtime")
public class RealtimeController {

    private final VideoStreamService videoStreamService;
    private final OpenCvIntegrationService openCvIntegrationService;
    private final AiInferenceClient aiInferenceClient;
    private final FusionService fusionService;
    private final AdviceService adviceService;
    private final EmotionTypeProperties emotionTypeProperties;

    public RealtimeController(VideoStreamService videoStreamService,
                              OpenCvIntegrationService openCvIntegrationService,
                              AiInferenceClient aiInferenceClient,
                              FusionService fusionService,
                              AdviceService adviceService,
                              EmotionTypeProperties emotionTypeProperties) {
        this.videoStreamService = videoStreamService;
        this.openCvIntegrationService = openCvIntegrationService;
        this.aiInferenceClient = aiInferenceClient;
        this.fusionService = fusionService;
        this.adviceService = adviceService;
        this.emotionTypeProperties = emotionTypeProperties;
    }

    @GetMapping("/emotion-types")
    public List<String> emotionTypes() {
        return emotionTypeProperties.getTypes();
    }

    @PostMapping("/infer")
    public Mono<RealtimeInferenceResponse> infer(@Valid @RequestBody RealtimeInferenceRequest request) {
        Mono<String> streamWindow = videoStreamService.extractWindow(request.taskId());
        Mono<String> faceContext = openCvIntegrationService.detectFaceContext(request.taskId());

        return Mono.zip(streamWindow, faceContext)
                .flatMap(ignored -> Mono.zip(
                        aiInferenceClient.inferAudio(request.taskId()),
                        aiInferenceClient.inferFace(request.taskId()),
                        aiInferenceClient.inferMicroExpression(request.taskId())
                ))
                .flatMap(results -> fusionService.fuse(List.of(results.getT1(), results.getT2(), results.getT3())))
                .map(this::toResponse)
                .map(fused -> new RealtimeInferenceResponse(request.taskId(), fused, adviceService.generate(fused.emotion())));
    }

    private FusedEmotionResponse toResponse(FusedEmotionResponse fused) {
        if (emotionTypeProperties.getTypes().contains(fused.emotion())) {
            return fused;
        }
        return new FusedEmotionResponse("neutral", fused.confidence(), fused.signals());
    }
}
