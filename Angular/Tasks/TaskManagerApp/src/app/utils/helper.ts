import { notificationType } from '../types/notificationType';

export function emptyTask() {
  return {
    id: '',
    title: '',
    description: '',
    priority: '',
    category: '',
    tag: '',
    date: '',
    isCompleted: false,
  };
}

export function emptyNotification() {
  return {
    message: '',
    type: 'info' as notificationType,
  };
}
