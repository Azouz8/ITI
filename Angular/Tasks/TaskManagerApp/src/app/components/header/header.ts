import { Component } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.html',
  styleUrl: './header.css',
})
export class Header {
  counter: number = 0;

  ngOnInit() {
    setInterval(() => {
      this.counter++;
    }, 1000);
  }
}
