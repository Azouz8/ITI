import { inject, Injectable } from '@angular/core';
import { Observable, map, throwError } from 'rxjs';
import { Router } from '@angular/router';
import { ApiService } from '../apiService/apiService';
import { NotificationService } from '../notificationService/notificationService';

export interface User {
  id?: string;
  firstName: string;
  lastName: string;
  email: string;
  password: string;
  age: string;
  gender: string;
}

const ENDPOINT = 'users';
const LOGGED_IN_KEY = 'loggedInUser';

@Injectable({
  providedIn: 'root',
})
export class UserApiService {
  private api = inject(ApiService);
  private router = inject(Router);
  private notificationService = inject(NotificationService);

  getLoggedInUser(): User | null {
    const raw = localStorage.getItem(LOGGED_IN_KEY) ?? sessionStorage.getItem(LOGGED_IN_KEY);
    return raw ? (JSON.parse(raw) as User) : null;
  }

  isLoggedIn(): boolean {
    return this.getLoggedInUser() !== null;
  }

  logout(): void {
    localStorage.removeItem(LOGGED_IN_KEY);
    sessionStorage.removeItem(LOGGED_IN_KEY);
    this.router.navigate(['/login']);
  }

  register(user: User): void {
    user.email = user.email.trim().toLowerCase();
    this.api.getByQuery<User>(ENDPOINT, { email: user.email }).subscribe((matches) => {
      if (matches.length > 0) {
        this.notificationService.show({
          message: 'An account with this email already exists.',
          type: 'error',
        });
        return;
      }

      this.api.create<User>(ENDPOINT, user).subscribe({
        next: () => {
          this.notificationService.show({
            message: 'Account Created Successfully!',
            type: 'info',
          });
          setTimeout(() => this.router.navigate(['/login']), 1500);
        },
        error: () => {
          this.notificationService.show({
            message: 'Registration failed. Please try again.',
            type: 'error',
          });
        },
      });
    });
  }

  login(email: string, password: string, remember: boolean): void {
    const cleanEmail = email.trim().toLowerCase();

    this.api.getByQuery<User>(ENDPOINT, { email: cleanEmail }).subscribe((matches) => {
      console.log('Server Response:', matches);
      const match = matches.find(
        (u) => u.email.toLowerCase() === cleanEmail && u.password === password,
      );

      if (!match) {
        console.log('No match found for:', cleanEmail, password);
        this.notificationService.show({
          message: 'Invalid email or password.',
          type: 'error',
        });
        return;
      }

      const storage = remember ? localStorage : sessionStorage;
      storage.setItem(LOGGED_IN_KEY, JSON.stringify(match));
      this.notificationService.show({ message: 'Welcome Back!', type: 'info' });
      setTimeout(() => this.router.navigate(['/home']), 1500);
    });
  }

  getAllUsers(): Observable<User[]> {
    return this.api.getAll<User>(ENDPOINT);
  }

  getUserById(id: string): Observable<User> {
    return this.api.getById<User>(ENDPOINT, id);
  }

  updateUser(id: string, user: Partial<User>): Observable<User> {
    return this.api.patch<User>(ENDPOINT, id, user);
  }

  deleteUser(id: string): Observable<User> {
    return this.api.delete<User>(ENDPOINT, id);
  }
}
