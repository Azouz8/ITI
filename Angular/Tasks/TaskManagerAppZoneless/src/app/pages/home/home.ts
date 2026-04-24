import { Component } from '@angular/core';
import { Carousel } from '../../components/carousel/carousel';

@Component({
  selector: 'app-home',
  imports: [Carousel],
  templateUrl: './home.html',
  styles: `
    .card {
      border-radius: 12px;
      transition: 0.3s;
    }

    .card:hover {
      transform: translateY(-4px);
      box-shadow: 0 10px 20px rgba(0, 0, 0, 0.15);
    }
  `,
})
export default class Home {}
