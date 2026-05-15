package com.make669.emotion.backend.service;

import org.springframework.stereotype.Service;

@Service
public class StreamingService {

    public String handleMessage(String message) {
        return "stream-placeholder:" + message;
    }
}
