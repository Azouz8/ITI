import { Component } from '@angular/core';
import {
  AbstractControl,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  ValidationErrors,
  Validators,
} from '@angular/forms';
import { RouterModule } from '@angular/router';
import { UserApiService } from '../../services/userApiService/userApiService';

function typeValidatorInt(control: AbstractControl): ValidationErrors | null {
  const age = control.value;
  if (!age) return null;
  const isNumber = !isNaN(parseFloat(age)) && isFinite(age);
  return isNumber ? null : { typeMismatch: true };
}

function matchPassword(control: AbstractControl): ValidationErrors | null {
  const password = control.get('password')?.value;
  const confirmPassword = control.get('confirmPassword')?.value;
  return password === confirmPassword ? null : { passwordMismatch: true };
}

@Component({
  selector: 'app-signup',
  standalone: true,
  imports: [RouterModule, ReactiveFormsModule],
  templateUrl: './signup.html',
  styleUrl: './signup.css',
})
export default class Signup {
  constructor(private auth: UserApiService) {}

  form = new FormGroup(
    {
      firstName: new FormControl('', [Validators.required, Validators.minLength(3)]),
      lastName: new FormControl('', [Validators.required, Validators.minLength(3)]),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, Validators.minLength(8)]),
      confirmPassword: new FormControl('', [Validators.required]),
      age: new FormControl('', [
        Validators.required,
        Validators.min(6),
        Validators.max(99),
        typeValidatorInt,
      ]),
      gender: new FormControl('Male'),
    },
    { validators: [matchPassword] },
  );

  onSubmit() {
    if (this.form.invalid) return;
    const { firstName, lastName, email, password, age, gender } = this.form.value;
    this.auth.register({
      firstName: firstName!,
      lastName: lastName!,
      email: email!,
      password: password!,
      age: age!,
      gender: gender!,
    });
  }
}
