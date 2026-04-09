import type { ISound } from "../interfaces/soundInterface.js";
import {
  playSound,
  playBackgroundSound,
  stopBackgroundSound,
} from "../utils/soundUtility.js";

export class Sound implements ISound {
  playBackgroundSound(): void {
    playBackgroundSound("assets/audio/fulltrack.mp3");
  }
  stopBackgroundSound(): void {
    stopBackgroundSound();
  }
  playOpenCardSound(): void {
    playSound("assets/audio/flip.mp3");
  }
  playUnmatchedSound(): void {
    playSound("assets/audio/fail.mp3");
  }
  playMatchedSound(): void {
    playSound("assets/audio/good.mp3");
  }
  playGameOverSound(): void {
    playSound("assets/audio/game-over.mp3");
  }
}
