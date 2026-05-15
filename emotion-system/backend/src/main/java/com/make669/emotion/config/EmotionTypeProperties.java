package com.make669.emotion.config;

import java.util.ArrayList;
import java.util.List;
import org.springframework.boot.context.properties.ConfigurationProperties;

@ConfigurationProperties(prefix = "emotion")
public class EmotionTypeProperties {

    private List<String> types = new ArrayList<>(List.of("neutral", "happy", "sad", "angry", "anxious", "fear"));

    public List<String> getTypes() {
        return types;
    }

    public void setTypes(List<String> types) {
        this.types = types;
    }
}
