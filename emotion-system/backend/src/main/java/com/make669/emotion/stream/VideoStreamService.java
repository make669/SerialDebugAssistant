package com.make669.emotion.stream;

import org.springframework.stereotype.Service;
import reactor.core.publisher.Mono;

@Service
public class VideoStreamService {

    public Mono<String> extractWindow(long taskId) {
        return Mono.just("TODO: integrate FFmpeg/WebRTC stream slicing for task " + taskId);
    }
}
