import { Component } from '@angular/core';
import { Header } from './components/header/header';
import { Footer } from './components/footer/footer';
import { TodoForm } from './components/todoForm/todoForm';
import { CardList } from './components/cardList/cardList';
import { Carousel } from './components/carousel/carousel';
import { CardData } from './components/models/cardModel';
import { emptyCard, emptyNotification } from './utils/helper';
import { Notification } from './components/notification/notification';
import { NotificationModel } from './components/models/notificationModel';

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  styleUrl: './app.css',
  imports: [Header, Footer, TodoForm, CardList, Carousel, Notification],
})
export class App {
  todoList: CardData[] = [];
  editCard: CardData = emptyCard();
  notification: NotificationModel = emptyNotification();
  getCard(card: CardData) {
    this.todoList.push(card);
    console.log(this.todoList);
  }

  editTask(card: CardData) {
    console.log(this.todoList);
    this.editCard = card;
  }
  updateCard(card: CardData) {
    const index = this.todoList.findIndex((c) => c.id === card.id);
    if (index !== -1) {
      this.todoList[index] = card;
    }
  }
  getNotification(notification: NotificationModel) {
    this.notification.message = notification.message;
    this.notification.type = notification.type;
    setTimeout(() => {
      this.notification.message = '';
    }, 3000);
  }
}
