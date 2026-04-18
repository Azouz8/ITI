import { Component, EventEmitter, Input, Output, output } from '@angular/core';
import { Card } from '../card/card';
import { FormsModule } from '@angular/forms';
import { v4 as uuid } from 'uuid';
import { CardData } from '../models/cardModel';
import { emptyCard } from '../../utils/helper';
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
  @Input()
  card: CardData = emptyCard();
  @Output()
  sendCardData = new EventEmitter<CardData>();
  @Output()
  updateCard = new EventEmitter<CardData>();
  @Output()
  sendNotification = new EventEmitter<NotificationModel>();

  saveData() {
    let newCard: CardData = { ...this.card, id: generateId() };
    for (let c in newCard) {
      let key = c as keyof CardData;
      if (newCard[key] === '') {
        this.sendNotification.emit({
          message: key.at(0)!.toUpperCase().concat(key.slice(1, key.length)) + ' Field is required',
          type: 'error',
        });
        return;
      }
    }
    this.sendCardData.emit(newCard);
    this.sendNotification.emit({ message: 'Task Added Successfully!', type: 'info' });
    this.card = emptyCard();
  }
  saveEditedCard() {
    this.updateCard.emit(this.card);
    this.sendNotification.emit({ message: 'Task Updated Successfully!', type: 'info' });
    this.card = emptyCard();
  }
}
