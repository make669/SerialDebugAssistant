package com.make669.emotion.backend.controller;

import com.make669.emotion.backend.dto.TaskRequest;
import com.make669.emotion.backend.dto.TaskResponse;
import com.make669.emotion.backend.service.TaskService;
import jakarta.validation.Valid;
import org.springframework.http.MediaType;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import reactor.core.publisher.Mono;

@RestController
@RequestMapping(path = "/api/tasks", produces = MediaType.APPLICATION_JSON_VALUE)
public class TaskController {

    private final TaskService taskService;

    public TaskController(TaskService taskService) {
        this.taskService = taskService;
    }

    @PostMapping("/start")
    public Mono<TaskResponse> start(@Valid @RequestBody TaskRequest request) {
        return Mono.just(taskService.start(request));
    }

    @PostMapping("/{taskId}/stop")
    public Mono<TaskResponse> stop(@PathVariable String taskId) {
        return Mono.just(taskService.stop(taskId));
    }

    @GetMapping("/{taskId}")
    public Mono<TaskResponse> get(@PathVariable String taskId) {
        return Mono.just(taskService.get(taskId));
    }
}
