import type { ICard } from "../interfaces/cardInterface.js";

export class Card implements ICard {
  id: number;
  imageUrl: string;
  isFlipped: boolean;
  isMatched: boolean;
  cardEl: HTMLElement | null = null;

  constructor(id: number, imageUrl: string) {
    this.id = id;
    this.imageUrl = imageUrl;
    this.isFlipped = false;
    this.isMatched = false;
  }
  flipCard(): void {
    this.isFlipped = true;
    this.cardEl?.classList.add("flipped");
  }
  unflipCard(): void {
    this.isFlipped = false;
    this.cardEl?.classList.remove("flipped");
  }
  makeUnclickable(): void {
    this.isMatched = true;
    this.cardEl?.style.setProperty("pointer-events", "none");
  }
  renderCard(): HTMLElement {
    const cardEl = document.createElement("div");
    const cardInner = document.createElement("div");
    const cardFront = document.createElement("div");
    const cardBack = document.createElement("div");
    const frontImg = document.createElement("img");
    const backImg = document.createElement("img");

    cardEl.classList.add("card");
    cardInner.classList.add("card-inner");
    cardFront.classList.add("card-front");
    cardBack.classList.add("card-back");

    frontImg.src = "assets/back.jpg";
    backImg.src = this.imageUrl;


    cardFront.appendChild(frontImg);
    cardBack.appendChild(backImg);
    cardInner.appendChild(cardFront);
    cardInner.appendChild(cardBack);
    cardEl.appendChild(cardInner);

    this.cardEl = cardEl;

    return cardEl;
  }
}
