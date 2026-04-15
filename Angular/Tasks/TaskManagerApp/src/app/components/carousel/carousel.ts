import { Component } from '@angular/core';

@Component({
  selector: 'app-carousel',
  imports: [],
  templateUrl: './carousel.html',
  styleUrl: './carousel.css',
})
export class Carousel {
  current: number = 0;
  isAutomated: boolean = false;
  imgs: string[] = ['assets/1.jpg', 'assets/2.jpg', 'assets/3.jpg', 'assets/4.jpg'];
  moveForward() {
    this.current = (this.current + 1) % this.imgs.length;
    this.automateCarousel();
  }
  moveBackward() {
    this.current = (this.current - 1 + this.imgs.length) % this.imgs.length;
    this.automateCarousel();
  }
  automateCarousel() {
    if (!this.isAutomated) {
      this.isAutomated = true;
      setInterval(() => {
        this.current = (this.current + 1) % this.imgs.length;
      }, 2000);
    }
  }
}
