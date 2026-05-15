package com.make669.emotion.advice;

import org.springframework.stereotype.Service;

@Service
public class AdviceService {

    public String generate(String emotion) {
        return switch (emotion) {
            case "anxious", "fear" -> "Keep communication calm and lower questioning pressure.";
            case "angry" -> "De-escalate conflict and confirm key facts slowly.";
            case "sad" -> "Use supportive language and avoid rapid topic switching.";
            default -> "Continue normal communication and monitor emotion changes.";
        };
    }
}
