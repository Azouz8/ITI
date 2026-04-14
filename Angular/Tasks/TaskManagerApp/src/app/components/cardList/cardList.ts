import { Component } from '@angular/core';
import { Card } from "../card/card";

@Component({
  templateUrl: './cardList.html',
  selector: 'app-cardList',
  styleUrl: './cardList.css',
  imports: [Card],
})
export class CardList {}
