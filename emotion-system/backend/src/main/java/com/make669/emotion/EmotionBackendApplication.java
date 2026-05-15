package com.make669.emotion;

import com.make669.emotion.config.EmotionTypeProperties;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.context.properties.EnableConfigurationProperties;

@SpringBootApplication
@EnableConfigurationProperties(EmotionTypeProperties.class)
public class EmotionBackendApplication {

    public static void main(String[] args) {
        SpringApplication.run(EmotionBackendApplication.class, args);
    }
}
