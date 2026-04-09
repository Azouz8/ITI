import type { IProgressBar } from "../interfaces/progressBarInterface.js";

export class ProgressBar implements IProgressBar {
  progress: number;
  progressBarElement: HTMLElement;
  constructor() {
    this.progress = 0;
    this.progressBarElement = document.getElementById("progress-bar")!;
  }
  incrementProgressBar(matchedPairs: number, totalPairs: number): void {
    this.progress = (matchedPairs / totalPairs) * 100;
    this.progressBarElement.style.width = `${this.progress}%`;
  }
}
