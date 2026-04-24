import { Component } from '@angular/core';
import { RouterLinkActive, RouterLinkWithHref } from '@angular/router';
import { UserApiService } from '../../services/userApiService/userApiService';

@Component({
  selector: 'app-header',
  imports: [RouterLinkActive, RouterLinkWithHref],
  templateUrl: './header.html',
  styles: ``,
})
export class Header {
  constructor(private auth: UserApiService) {}
  onLogout() {
    this.auth.logout();
  }
}
