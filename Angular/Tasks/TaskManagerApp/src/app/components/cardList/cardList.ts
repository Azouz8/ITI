import { Component, EventEmitter, Input, Output, SimpleChanges } from '@angular/core';
import { Card } from '../card/card';
import { TaskData } from '../models/cardModel';
import { NotificationModel } from '../models/notificationModel';
import { emptyTask } from '../../utils/helper';

@Component({
  templateUrl: './cardList.html',
  selector: 'app-cardList',
  styleUrl: './cardList.css',
  imports: [Card],
})
export class CardList {
  taskList: TaskData[] = [];
  isAllDone: boolean = false;
  @Input() task: TaskData = emptyTask();
  @Input() updatedTask: TaskData = emptyTask();
  @Output() updateTaskEvent = new EventEmitter<TaskData>();
  @Output() notification = new EventEmitter<NotificationModel>();

  get categories() {
    const incompleteTasks = this.taskList.filter((card) => !card.isCompleted);
    const allCategories = incompleteTasks.map((card) => card.category);
    return [...new Set(allCategories)];
  }

  checkIsAllDone() {
    const incompleteTasks = this.taskList.filter((card) => !card.isCompleted);

    if (incompleteTasks.length === 0) {
      this.isAllDone = true;
      this.notification.emit({
        message: 'Congrats, you have completed all the tasks',
        type: 'info',
      } as NotificationModel);
    } else {
      this.isAllDone = false;
    }
  }

  ngOnDestroy() {
    console.log('LIST IS DEAD');
  }

  deleteTask(task: TaskData) {
    for (let i = 0; i < this.taskList.length; i++) {
      if (this.taskList[i].id == task.id) {
        this.taskList.splice(i, 1);
        console.log(this.taskList);
      }
    }
  }

  getNotification(notification: NotificationModel) {
    this.notification.emit(notification);
  }

  passTaskToBeUpdated(task: TaskData) {
    this.updateTaskEvent.emit(task);
  }

  updateTask(task: TaskData) {
    const index = this.taskList.findIndex((t) => t.id === task.id);
    if (index !== -1) {
      this.taskList[index] = task;
    }
  }

  ngOnChanges(changes: SimpleChanges) {
    console.log(changes);

    if (changes['task'] && !changes['task'].firstChange) {
      console.log('hereee');
      this.taskList.push(this.task);
      this.task = emptyTask();
    }

    if (changes['updatedTask'] && !changes['updatedTask'].firstChange) {
      console.log('hereee');
      const updated = changes['updatedTask'].currentValue;
      const index = this.taskList.findIndex((c) => c.id === this.updatedTask.id);
      if (index !== -1) {
        this.taskList[index] = updated;
      }
    }
  }
}
