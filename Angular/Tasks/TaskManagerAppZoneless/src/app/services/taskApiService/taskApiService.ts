import { computed, inject, Injectable, signal } from '@angular/core';
import { Observable, tap } from 'rxjs';
import { ApiService } from '../apiService/apiService';
import { NotificationService } from '../notificationService/notificationService';
import { UserApiService } from '../userApiService/userApiService';

export interface TaskModel {
  id: string;
  userId: string;
  title: string;
  description: string;
  priority: string;
  category: string;
  tag: string;
  date: string;
  isCompleted: boolean;
}

const ENDPOINT = 'tasks';

@Injectable({
  providedIn: 'root',
})
export class TaskApiService {
  private api = inject(ApiService);
  private notificationService = inject(NotificationService);
  private userApiService = inject(UserApiService);

  tasks = signal<TaskModel[]>([]);
  selectedTask = signal<TaskModel | null>(null);
  isAllDone = false;

  categories = computed(() => {
    const incomplete = this.tasks().filter((t) => !t.isCompleted);
    const allCats = incomplete.map((t) => t.category);
    return [...new Set(allCats)];
  });

  loadTasksForCurrentUser(): void {
    const user = this.userApiService.getLoggedInUser();
    if (!user?.id) return;

    this.api
      .getByQuery<TaskModel>(ENDPOINT, { userId: user.id })
      .subscribe((tasks) => this.tasks.set(tasks));
  }

  setSelectedTask(task: TaskModel): void {
    this.selectedTask.set(task);
  }

  clearSelectedTask(): void {
    this.selectedTask.set(null);
  }

  addTask(task: Omit<TaskModel, 'id' | 'userId'>): void {
    const user = this.userApiService.getLoggedInUser();
    if (!user?.id) return;

    const hasEmpty = Object.values(task).some((v) => v === '' || v === null || v === undefined);
    if (hasEmpty) return;

    const newTask: Omit<TaskModel, 'id'> = { ...task, userId: user.id };

    this.api.create<Omit<TaskModel, 'id'>>(ENDPOINT, newTask).subscribe({
      next: (created) => {
        this.tasks.update((current) => [...current, created as TaskModel]);
        this.notificationService.show({ message: 'Task Added Successfully!', type: 'info' });
      },
      error: () => {
        this.notificationService.show({ message: 'Failed to add task.', type: 'error' });
      },
    });
  }

  updateTask(updatedTask: TaskModel, showNotification: boolean): void {
    this.api.update<TaskModel>(ENDPOINT, updatedTask.id, updatedTask).subscribe({
      next: (result) => {
        this.tasks.update((current) => current.map((t) => (t.id === result.id ? result : t)));
        if (showNotification) {
          this.notificationService.show({ message: 'Task Updated Successfully', type: 'info' });
        }
        this.checkIsAllDone();
      },
      error: () => {
        this.notificationService.show({ message: 'Failed to update task.', type: 'error' });
      },
    });
  }

  deleteTask(task: TaskModel): void {
    this.api.delete<TaskModel>(ENDPOINT, task.id).subscribe({
      next: () => {
        this.tasks.update((current) => current.filter((t) => t.id !== task.id));
        this.notificationService.show({ message: 'Task Deleted Successfully', type: 'info' });
      },
      error: () => {
        this.notificationService.show({ message: 'Failed to delete task.', type: 'error' });
      },
    });
  }

  private checkIsAllDone(): void {
    const incomplete = this.tasks().filter((t) => !t.isCompleted);
    if (incomplete.length === 0) {
      this.isAllDone = true;
      this.notificationService.show({
        message: 'Congrats, you have completed all the tasks',
        type: 'info',
      });
    } else {
      this.isAllDone = false;
    }
  }
}
