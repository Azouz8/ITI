import { Component } from '@angular/core';

@Component({
  templateUrl: './card.html',
  selector: 'app-card',
  styleUrl: './card.css',
})
export class Card {
  title: string = '';
  description: string = '';
  priority: string = '';
  category: string = '';
  tag: string = '';
  date: string = '';
}
