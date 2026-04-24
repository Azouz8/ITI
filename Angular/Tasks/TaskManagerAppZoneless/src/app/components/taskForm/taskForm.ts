import { Component, inject, Input, Output, EventEmitter, OnInit } from '@angular/core';
import { TaskApiService, TaskModel } from '../../services/taskApiService/taskApiService';
import {
  FormControl,
  FormGroup,
  FormsModule,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';

@Component({
  selector: 'app-form',
  imports: [FormsModule, ReactiveFormsModule],
  templateUrl: './taskForm.html',
  styleUrl: './taskForm.css',
})
export default class Form implements OnInit {
  @Input() isEditMode = false;
  @Output() saved = new EventEmitter<void>();

  taskService = inject(TaskApiService);

  ngOnInit() {
    if (this.isEditMode) {
      const selected = this.taskService.selectedTask();
      if (selected) {
        this.form.patchValue({
          title: selected.title,
          description: selected.description,
          priority: selected.priority,
          category: selected.category,
          tag: selected.tag,
          date: selected.date,
        });
      }
    }
  }

  addTask() {
    if (this.form.invalid) return;
    const newTask = { ...this.form.value, isCompleted: false } as Omit<TaskModel, 'id' | 'userId'>;
    this.taskService.addTask(newTask);
    this.form.reset({
      title: '',
      description: '',
      priority: 'Low',
      category: 'Sports',
      tag: 'Tag1',
      date: new Date().toISOString().split('T')[0],
    });
  }

  saveEdit() {
    if (this.form.invalid) return;
    const selected = this.taskService.selectedTask()!;
    const updatedTask = {
      ...selected,
      ...this.form.value,
    } as TaskModel;
    this.taskService.updateTask(updatedTask, true);
    this.saved.emit();
  }

  form = new FormGroup({
    title: new FormControl('', [Validators.required]),
    description: new FormControl('', [Validators.required]),
    priority: new FormControl('Low', [Validators.required]),
    category: new FormControl('Sports', [Validators.required]),
    tag: new FormControl('Tag1', [Validators.required]),
    date: new FormControl(new Date().toISOString().split('T')[0], [Validators.required]),
  });
}
