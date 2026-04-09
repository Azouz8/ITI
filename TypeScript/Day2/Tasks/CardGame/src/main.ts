import { Sound } from "./classes/sound.js";
import { ProgressBar } from "./classes/progressBar.js";
import { Game } from "./classes/game.js";
import { GameState } from "./classes/gameState.js";

const sound = new Sound();
const progressBar = new ProgressBar();
const game = new Game();
const gameState = new GameState(game.getCards().length / 2, sound, progressBar);

const board = document.getElementById("game-board");

game.getCards().forEach((card) => {
  const cardEl = card.renderCard();

  cardEl.addEventListener("click", () => {
    if (card.isFlipped || card.isMatched) return;
    if (gameState.isComparing) return;
    card.flipCard();
    gameState.flipCard(card);
  });

  board!.appendChild(cardEl);
});
