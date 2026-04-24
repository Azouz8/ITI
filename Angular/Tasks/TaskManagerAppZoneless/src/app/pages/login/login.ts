import { Component } from '@angular/core';
import { FormsModule, NgForm } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { UserApiService } from '../../services/userApiService/userApiService';

@Component({
  selector: 'app-login',
  templateUrl: './login.html',
  styleUrl: './login.css',
  imports: [RouterModule, FormsModule],
})
export default class Login {
  constructor(private auth: UserApiService) {}

  onSubmit(form: NgForm) {
    if (form.invalid) return;
    const { email, password, rememberMe } = form.value;
    this.auth.login(email, password, rememberMe);
  }
}
