package com.make669.emotion.backend.websocket;

import com.make669.emotion.backend.service.StreamingService;
import org.springframework.stereotype.Component;
import org.springframework.web.reactive.socket.WebSocketHandler;
import org.springframework.web.reactive.socket.WebSocketMessage;
import org.springframework.web.reactive.socket.WebSocketSession;
import reactor.core.publisher.Mono;

@Component
public class EmotionWebSocketHandler implements WebSocketHandler {

    private final StreamingService streamingService;

    public EmotionWebSocketHandler(StreamingService streamingService) {
        this.streamingService = streamingService;
    }

    @Override
    public Mono<Void> handle(WebSocketSession session) {
        return session.send(session.receive()
                .map(WebSocketMessage::getPayloadAsText)
                .map(streamingService::handleMessage)
                .map(session::textMessage));
    }
}
