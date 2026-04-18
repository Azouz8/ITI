import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Card } from '../card/card';
import { CardData } from '../models/cardModel';
import { NotificationModel } from '../models/notificationModel';

@Component({
  templateUrl: './cardList.html',
  selector: 'app-cardList',
  styleUrl: './cardList.css',
  imports: [Card],
})
export class CardList {
  @Input()
  todoList: CardData[] = [];
  @Output()
  editTaskEvent = new EventEmitter<CardData>();
  @Output() notification = new EventEmitter<NotificationModel>();
  get categories() {
    const allCategories = this.todoList.map((card) => card.category);
    return [...new Set(allCategories)];
  }

  deleteTask(card: CardData) {
    for (let i = 0; i < this.todoList.length; i++) {
      if (this.todoList[i].id == card.id) {
        this.todoList.splice(i, 1);
        console.log(this.todoList);
      }
    }
  }

  getNotification(notification: NotificationModel) {
    this.notification.emit(notification);
  }

  editTask(card: CardData) {
    this.editTaskEvent.emit(card);
  }
}
