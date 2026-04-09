let backgroundAudio: HTMLAudioElement | null = null;

export const playSound = (filePath: string): void => {
  const audio = new Audio(filePath);
  audio.play().catch((error) => {
    console.error("Playback failed:", error);
  });
};
export function playBackgroundSound(path: string): void {
  backgroundAudio = new Audio(path);
  backgroundAudio.play();
}

export function stopBackgroundSound(): void {
  if (backgroundAudio) {
    backgroundAudio.pause();
    backgroundAudio.currentTime = 0;
    backgroundAudio = null;
  }
}
