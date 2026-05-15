package com.make669.emotion.task;

import java.util.Map;
import java.util.concurrent.ConcurrentHashMap;
import java.util.concurrent.atomic.AtomicLong;
import org.springframework.stereotype.Service;
import reactor.core.publisher.Mono;

@Service
public class TaskService {

    private final AtomicLong taskIds = new AtomicLong(1000);
    private final Map<Long, TaskResponse> tasks = new ConcurrentHashMap<>();

    public Mono<TaskResponse> create(TaskRequest request) {
        long id = taskIds.incrementAndGet();
        TaskResponse response = new TaskResponse(id, request.streamUrl(), TaskStatus.RUNNING);
        tasks.put(id, response);
        return Mono.just(response);
    }

    public Mono<TaskResponse> stop(long taskId) {
        TaskResponse current = tasks.get(taskId);
        if (current == null) {
            return Mono.empty();
        }

        TaskResponse stopped = new TaskResponse(current.taskId(), current.streamUrl(), TaskStatus.STOPPED);
        tasks.put(taskId, stopped);
        return Mono.just(stopped);
    }

    public Mono<TaskResponse> get(long taskId) {
        return Mono.justOrEmpty(tasks.get(taskId));
    }
}
