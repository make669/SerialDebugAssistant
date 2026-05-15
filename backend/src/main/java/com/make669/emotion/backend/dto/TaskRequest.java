package com.make669.emotion.backend.dto;

import jakarta.validation.constraints.NotBlank;

public record TaskRequest(@NotBlank String source) {
}
