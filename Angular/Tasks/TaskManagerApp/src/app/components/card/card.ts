import { Component, EventEmitter, Input, Output } from '@angular/core';
import { TaskData } from '../models/cardModel';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { faTrashCan } from '@fortawesome/free-solid-svg-icons';
import { faEdit } from '@fortawesome/free-solid-svg-icons';
import { NotificationModel } from '../models/notificationModel';
import { CardList } from '../cardList/cardList';

@Component({
  templateUrl: './card.html',
  selector: 'app-card',
  styleUrl: './card.css',
  imports: [FontAwesomeModule],
})
export class Card {
  @Input() cardData!: TaskData;
  @Output() delete = new EventEmitter<TaskData>();
  @Output() edit = new EventEmitter<TaskData>();
  @Output() notification = new EventEmitter<NotificationModel>();
  @Output() statusChanged = new EventEmitter<TaskData>();
  faTrash = faTrashCan;
  faEdit = faEdit;
  toggleTaskStatus() {
    this.cardData.isCompleted = !this.cardData.isCompleted;
    this.statusChanged.emit(this.cardData);
  }
  onDelete() {
    this.notification.emit({ message: 'Task Deleted Successfully!', type: 'info' });
    this.delete.emit(this.cardData);
  }
  onEdit() {
    this.edit.emit(this.cardData);
  }
}
