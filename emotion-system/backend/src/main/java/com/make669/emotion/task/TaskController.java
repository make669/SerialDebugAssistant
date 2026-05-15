package com.make669.emotion.task;

import jakarta.validation.Valid;
import org.springframework.http.HttpStatus;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PathVariable;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseStatus;
import org.springframework.web.bind.annotation.RestController;
import reactor.core.publisher.Mono;

@RestController
@RequestMapping("/api/tasks")
public class TaskController {

    private final TaskService taskService;

    public TaskController(TaskService taskService) {
        this.taskService = taskService;
    }

    @PostMapping
    @ResponseStatus(HttpStatus.CREATED)
    public Mono<TaskResponse> create(@Valid @RequestBody TaskRequest request) {
        return taskService.create(request);
    }

    @PostMapping("/{taskId}/stop")
    public Mono<TaskResponse> stop(@PathVariable long taskId) {
        return taskService.stop(taskId);
    }

    @GetMapping("/{taskId}")
    public Mono<TaskResponse> get(@PathVariable long taskId) {
        return taskService.get(taskId);
    }
}
