import { Card } from "./card.js";
import type { ISound } from "../interfaces/soundInterface.js";
import type { IProgressBar } from "../interfaces/progressBarInterface.js";

export class GameState {
  flippedCards: Card[];
  matchedPairs: number;
  totalPairs: number;
  sound: ISound;
  progressBar: IProgressBar;
  isComparing: boolean;
  isBackgroundMusicPlaying: boolean;

  constructor(totalPairs: number, sound: ISound, progressBar: IProgressBar) {
    this.flippedCards = [];
    this.matchedPairs = 0;
    this.totalPairs = totalPairs;
    this.sound = sound;
    this.progressBar = progressBar;
    this.isComparing = false;
    this.isBackgroundMusicPlaying = false;
  }
  flipCard(card: Card): void {
    if (!this.isBackgroundMusicPlaying) {
      this.isBackgroundMusicPlaying = true;
      this.sound.playBackgroundSound();
    }
    this.sound.playOpenCardSound();
    this.flippedCards.push(card);
    if (this.flippedCards.length === 2) {
      this.compareCards();
    }
  }
  compareCards(): boolean {
    const isMatched: boolean =
      this.flippedCards[0]?.imageUrl === this.flippedCards[1]?.imageUrl;
    if (isMatched) {
      this.matchedPairs++;
      this.sound.playMatchedSound();
      this.progressBar.incrementProgressBar(this.matchedPairs, this.totalPairs);
      this.isGameFinished();
      this.flippedCards.forEach((card) => card.makeUnclickable());
      this.flippedCards = [];
    } else {
      this.isComparing = true;
      setTimeout(() => {
        this.flippedCards.forEach((card) => card.unflipCard());
        this.flippedCards = [];
        this.isComparing = false;
      }, 1000);
      this.sound.playUnmatchedSound();
    }

    return isMatched;
  }
  isGameFinished(): boolean {
    const isGameFinished: boolean = this.matchedPairs === this.totalPairs;
    if (isGameFinished) {
      this.sound.stopBackgroundSound();
      this.sound.playGameOverSound();
    }
    return isGameFinished;
  }
}
