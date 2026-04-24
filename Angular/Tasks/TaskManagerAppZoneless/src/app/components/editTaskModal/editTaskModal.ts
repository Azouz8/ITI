import { Component, EventEmitter, inject, Output } from '@angular/core';
import Form from '../taskForm/taskForm';
import { TaskApiService } from '../../services/taskApiService/taskApiService';

@Component({
  selector: 'app-edit-task-modal',
  imports: [Form],
  templateUrl: './editTaskModal.html',
  styleUrl: './editTaskModal.css',
})
export class EditTaskModal {
  @Output() closeModal = new EventEmitter<void>();
  taskService = inject(TaskApiService);

  close() {
    this.closeModal.emit();
  }
}
