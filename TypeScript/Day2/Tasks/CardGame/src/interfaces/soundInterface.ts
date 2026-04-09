export interface ISound {
  playBackgroundSound(): void;
  stopBackgroundSound(): void;
  playOpenCardSound(): void;
  playUnmatchedSound(): void;
  playMatchedSound(): void;
  playGameOverSound(): void;
}
