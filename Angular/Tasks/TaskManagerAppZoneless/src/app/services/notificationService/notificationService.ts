import { Injectable, signal } from '@angular/core';
import { NotificationModel } from '../../models/notificationModel';
import { emptyNotification } from '../../utils/helper';

@Injectable({
  providedIn: 'root',
})
export class NotificationService {
  notification = signal<NotificationModel>(emptyNotification());

  show(notification: NotificationModel) {
    this.notification.set(notification);

    setTimeout(() => {
      this.clear();
    }, 3000);
  }

  clear() {
    this.notification.set(emptyNotification());
  }
}
