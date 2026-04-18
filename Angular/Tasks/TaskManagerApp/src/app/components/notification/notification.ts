import { Component, Input } from '@angular/core';
import { NotificationModel } from '../models/notificationModel';

@Component({
  selector: 'app-notification',
  imports: [],
  templateUrl: './notification.html',
  styleUrl: './notification.css',
})
export class Notification {
  @Input()
  notification: NotificationModel = {
    message: '',
    type: 'info',
  };
}
