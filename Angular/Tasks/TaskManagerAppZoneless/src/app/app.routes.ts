import { Routes } from '@angular/router';
import { autoLoginMiddleware } from './services/userApiService/autoLoginMiddleware';
import { authMiddleware } from './services/userApiService/authMiddleware';

export const routes: Routes = [
  {
    path: '',
    redirectTo: 'login',
    pathMatch: 'full',
  },
  {
    path: 'login',
    loadComponent: () => import('./pages/login/login'),
    canActivate: [autoLoginMiddleware],
  },
  {
    path: 'signUp',
    loadComponent: () => import('./pages/signup/signup'),
    canActivate: [autoLoginMiddleware],
  },
  {
    path: '',
    loadComponent: () => import('./components/layout/layout'),
    canActivate: [authMiddleware],
    children: [
      {
        path: '',
        redirectTo: 'home',
        pathMatch: 'full',
      },
      {
        path: 'home',
        loadComponent: () => import('./pages/home/home'),
      },
      {
        path: 'addTask',
        loadComponent: () => import('./components/taskForm/taskForm'),
      },
      {
        path: 'tasks',
        loadComponent: () => import('./components/taskList/taskList'),
      },
    ],
  },
  {
    path: '**',
    loadComponent: () => import('./pages/not-found/not-found'),
  },
];
