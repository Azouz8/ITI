import { Component, EventEmitter, Input, Output } from '@angular/core';
import { CardData } from '../models/cardModel';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faTrashCan } from '@fortawesome/free-solid-svg-icons';
import { faEdit } from '@fortawesome/free-solid-svg-icons';
import { NotificationModel } from '../models/notificationModel';

@Component({
  templateUrl: './card.html',
  selector: 'app-card',
  styleUrl: './card.css',
  imports: [FontAwesomeModule],
})
export class Card {
  @Input() cardData!: CardData;
  @Output() delete = new EventEmitter<CardData>();
  @Output() edit = new EventEmitter<CardData>();
  @Output() notification = new EventEmitter<NotificationModel>();
  faTrash = faTrashCan;
  faEdit = faEdit;
  toggleTaskStatus() {
    this.cardData.isCompleted = !this.cardData.isCompleted;
  }
  onDelete() {
    this.notification.emit({ message: 'Task Deleted Successfully!', type: 'info' });
    this.delete.emit(this.cardData);
  }
  onEdit() {
    this.edit.emit(this.cardData);
  }
}
