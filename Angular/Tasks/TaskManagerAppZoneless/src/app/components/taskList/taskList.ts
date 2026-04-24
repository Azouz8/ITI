import { Component, inject, OnInit } from '@angular/core';
import { Task } from '../task/task';
import { TaskApiService, TaskModel } from '../../services/taskApiService/taskApiService';
import { EditTaskModal } from '../editTaskModal/editTaskModal';

@Component({
  selector: 'app-tasks',
  imports: [Task, EditTaskModal],
  templateUrl: './taskList.html',
  styleUrl: './taskList.css',
})
export default class Tasks implements OnInit {
  taskService = inject(TaskApiService);
  tasks = this.taskService.tasks;
  categories = this.taskService.categories;
  isModalOpen = false;

  ngOnInit() {
    this.taskService.loadTasksForCurrentUser();
  }

  openEditModal(task: TaskModel) {
    this.taskService.setSelectedTask(task);
    this.isModalOpen = true;
  }

  closeEditModal() {
    this.taskService.clearSelectedTask();
    this.isModalOpen = false;
  }
}
