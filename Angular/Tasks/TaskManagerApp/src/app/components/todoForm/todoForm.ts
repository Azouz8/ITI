import { Component, EventEmitter, Input, Output, output } from '@angular/core';
import { Card } from '../card/card';
import { FormsModule } from '@angular/forms';
import { v4 as uuid } from 'uuid';
import { TaskData } from '../models/cardModel';
import { emptyTask } from '../../utils/helper';
import { NotificationModel } from '../models/notificationModel';

function generateId() {
  const id = uuid().split('-')[0];
  return id;
}

@Component({
  templateUrl: './todoForm.html',
  selector: 'app-todoForm',
  styleUrl: './todoForm.css',
  imports: [FormsModule],
})
export class TodoForm {
  @Input() task: TaskData = emptyTask();
  @Output() sendTaskEvent = new EventEmitter<TaskData>();
  @Output() updateTaskEvent = new EventEmitter<TaskData>();
  @Output() sendNotificationEvent = new EventEmitter<NotificationModel>();

  saveData() {
    let newTask: TaskData = { ...this.task, id: generateId() };
    for (let c in newTask) {
      let key = c as keyof TaskData;
      if (newTask[key] === '') {
        this.sendNotificationEvent.emit({
          message: key.at(0)!.toUpperCase().concat(key.slice(1, key.length)) + ' Field is required',
          type: 'error',
        });
        return;
      }
    }
    this.sendTaskEvent.emit(newTask);
    this.sendNotificationEvent.emit({ message: 'Task Added Successfully!', type: 'info' });
    this.task = emptyTask();
  }
  saveEditedCard() {
    this.updateTaskEvent.emit(this.task);
    this.sendNotificationEvent.emit({ message: 'Task Updated Successfully!', type: 'info' });
    this.task = emptyTask();
  }
}
