package com.make669.emotion.backend.service;

import com.make669.emotion.backend.dto.TaskRequest;
import com.make669.emotion.backend.dto.TaskResponse;
import org.springframework.stereotype.Service;

import java.util.Map;
import java.util.UUID;
import java.util.concurrent.ConcurrentHashMap;

@Service
public class TaskService {

    private final Map<String, String> taskStatuses = new ConcurrentHashMap<>();

    public TaskResponse start(TaskRequest request) {
        String taskId = UUID.randomUUID().toString();
        taskStatuses.put(taskId, "RUNNING");
        return new TaskResponse(taskId, "RUNNING");
    }

    public TaskResponse stop(String taskId) {
        taskStatuses.put(taskId, "STOPPED");
        return new TaskResponse(taskId, "STOPPED");
    }

    public TaskResponse get(String taskId) {
        return new TaskResponse(taskId, taskStatuses.getOrDefault(taskId, "UNKNOWN"));
    }
}
