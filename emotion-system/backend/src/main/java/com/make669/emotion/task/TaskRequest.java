package com.make669.emotion.task;

import jakarta.validation.constraints.NotBlank;

public record TaskRequest(@NotBlank String streamUrl) {
}
