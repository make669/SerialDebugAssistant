package com.make669.emotion.opencv;

import org.springframework.stereotype.Service;
import reactor.core.publisher.Mono;

@Service
public class OpenCvIntegrationService {

    public Mono<String> detectFaceContext(long taskId) {
        return Mono.just("TODO: integrate OpenCV face detection/tracking for task " + taskId);
    }
}
