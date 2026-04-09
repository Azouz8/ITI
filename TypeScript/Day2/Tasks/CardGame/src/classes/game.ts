import { Card } from "./card.js";
import { cards as cardsData } from "../constants/cardsData.js";

export class Game {
  cards: Card[];
  constructor() {
    this.cards = cardsData.map((data) => new Card(data.id, data.imageUrl));
    this.randomizeCards();
  }
  randomizeCards(): void {
    for (let i = this.cards.length - 1; i > 0; i--) {
      const randomIndex = Math.floor(Math.random() * (i + 1));
      [this.cards[i], this.cards[randomIndex]] = [
        this.cards[randomIndex]!,
        this.cards[i]!,
      ];
    }
  }
  getCards(): Card[] {
    return this.cards;
  }
}
