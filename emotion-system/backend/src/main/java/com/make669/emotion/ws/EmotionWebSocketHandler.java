package com.make669.emotion.ws;

import com.fasterxml.jackson.core.JsonProcessingException;
import com.fasterxml.jackson.databind.ObjectMapper;
import java.time.Instant;
import org.springframework.stereotype.Component;
import org.springframework.web.reactive.socket.WebSocketHandler;
import org.springframework.web.reactive.socket.WebSocketMessage;
import org.springframework.web.reactive.socket.WebSocketSession;
import reactor.core.publisher.Flux;
import reactor.core.publisher.Mono;

@Component
public class EmotionWebSocketHandler implements WebSocketHandler {

    private final ObjectMapper objectMapper;

    public EmotionWebSocketHandler(ObjectMapper objectMapper) {
        this.objectMapper = objectMapper;
    }

    @Override
    public Mono<Void> handle(WebSocketSession session) {
        Flux<WebSocketMessage> welcome = Flux.just(session.textMessage(toJson(new WsMessage(
                Instant.now().toString(),
                "neutral",
                "TODO: wire realtime emotion stream"
        ))));
        Flux<WebSocketMessage> incomingMessages = session.receive()
                .map(message -> session.textMessage("echo:" + message.getPayloadAsText()));

        return session.send(welcome.concatWith(incomingMessages));
    }

    private String toJson(WsMessage message) {
        try {
            return objectMapper.writeValueAsString(message);
        } catch (JsonProcessingException ex) {
            return "{\"emotion\":\"neutral\",\"note\":\"serialization_error\"}";
        }
    }

    private record WsMessage(String timestamp, String emotion, String note) {
    }
}
