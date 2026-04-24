import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { UserApiService } from '../userApiService/userApiService';

export const autoLoginMiddleware: CanActivateFn = () => {
  const auth = inject(UserApiService);
  const router = inject(Router);

  if (auth.isLoggedIn()) {
    router.navigate(['/home']);
    return false;
  }

  return true;
};
