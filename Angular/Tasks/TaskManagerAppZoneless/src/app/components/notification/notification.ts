import { Component, inject, Input } from '@angular/core';
import { emptyNotification } from '../../utils/helper';
import { NotificationModel } from '../../models/notificationModel';
import { NgClass } from '@angular/common';
import { NotificationService } from '../../services/notificationService/notificationService';

@Component({
  selector: 'app-notification',
  imports: [NgClass],
  templateUrl: './notification.html',
  styleUrl: './notification.css',
})
export class Notification {
  private notifyService = inject(NotificationService);

  notification = this.notifyService.notification;
}
