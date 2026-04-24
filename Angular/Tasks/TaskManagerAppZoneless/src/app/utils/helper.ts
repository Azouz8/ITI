import { notificationType } from '../models/notificationModel';

export function emptyTask() {
  return {
    id: '',
    title: '',
    description: '',
    priority: 'Low',
    category: 'Sports',
    tag: 'Tag1',
    date: new Date().toISOString().split('T')[0],
    isCompleted: false,
  };
}

export function emptyNotification() {
  return {
    message: '',
    type: 'info' as notificationType,
  };
}
