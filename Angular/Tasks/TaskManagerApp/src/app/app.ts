import { Component } from '@angular/core';
import { Header } from './components/header/header';
import { Footer } from './components/footer/footer';
import { TodoForm } from './components/todoForm/todoForm';
import { CardList } from './components/cardList/cardList';
import { Carousel } from './components/carousel/carousel';
import { TaskData } from './components/models/cardModel';
import { emptyTask, emptyNotification } from './utils/helper';
import { Notification } from './components/notification/notification';
import { NotificationModel } from './components/models/notificationModel';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  styleUrl: './app.css',
  imports: [Header, Footer, TodoForm, CardList, Carousel, Notification],
})
export class App {
  task: TaskData = emptyTask();
  taskToBeUpdated: TaskData = emptyTask();
  notification: NotificationModel = emptyNotification();

  getCard(task: TaskData) {
    this.task = task;
  }

  passTaskToBeUpdated(task: TaskData) {
    this.taskToBeUpdated = task;
  }

  getNotification(notification: NotificationModel) {
    this.notification = notification;
    setTimeout(() => {
      this.notification.message = '';
    }, 3000);
  }
}
