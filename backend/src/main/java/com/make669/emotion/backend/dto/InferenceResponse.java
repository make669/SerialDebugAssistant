package com.make669.emotion.backend.dto;

public record InferenceResponse(String type, String emotion, double confidence) {
}
