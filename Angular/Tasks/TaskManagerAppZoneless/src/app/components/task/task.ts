import { Component, EventEmitter, inject, Input, Output } from '@angular/core';
import { TaskApiService, TaskModel } from '../../services/taskApiService/taskApiService';
import { NgClass } from '@angular/common';

const emptyTask = (): TaskModel => ({
  id: '',
  userId: '',
  title: '',
  description: '',
  priority: 'Low',
  category: '',
  tag: '',
  date: '',
  isCompleted: false,
});

@Component({
  selector: 'app-task',
  imports: [NgClass],
  templateUrl: './task.html',
  styles: ``,
})
export class Task {
  @Input() task: TaskModel = emptyTask();
  @Output() editClicked = new EventEmitter<TaskModel>();

  taskService = inject(TaskApiService);

  toggleTaskStatus() {
    const updatedTask = { ...this.task, isCompleted: !this.task.isCompleted };
    this.task = updatedTask;
    this.taskService.updateTask(updatedTask, false);
  }

  deleteTask() {
    this.taskService.deleteTask(this.task);
  }

  openEditModal() {
    this.editClicked.emit(this.task);
  }
}
