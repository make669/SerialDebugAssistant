package com.make669.emotion.ws;

import java.time.Instant;
import org.springframework.stereotype.Component;
import org.springframework.web.reactive.socket.WebSocketHandler;
import org.springframework.web.reactive.socket.WebSocketMessage;
import org.springframework.web.reactive.socket.WebSocketSession;
import reactor.core.publisher.Flux;
import reactor.core.publisher.Mono;

@Component
public class EmotionWebSocketHandler implements WebSocketHandler {

    @Override
    public Mono<Void> handle(WebSocketSession session) {
        Flux<WebSocketMessage> welcome = Flux.just(session.textMessage("{\"timestamp\":\"" + Instant.now() + "\",\"emotion\":\"neutral\",\"note\":\"TODO: wire realtime emotion stream\"}"));
        Flux<WebSocketMessage> echoes = session.receive()
                .map(message -> session.textMessage("echo:" + message.getPayloadAsText()));

        return session.send(welcome.concatWith(echoes));
    }
}
