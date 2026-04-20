import { Component, Input } from '@angular/core';
import { NotificationModel } from '../models/notificationModel';
import { emptyNotification } from '../../utils/helper';

@Component({
  selector: 'app-notification',
  imports: [],
  templateUrl: './notification.html',
  styleUrl: './notification.css',
})
export class Notification {
  @Input()
  notification: NotificationModel = emptyNotification();
}
