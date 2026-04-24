export type notificationType = 'info' | 'warning' | 'error';

export interface NotificationModel {
  message: string;
  type: notificationType;
}
