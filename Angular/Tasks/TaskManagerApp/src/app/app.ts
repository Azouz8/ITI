import { Component } from '@angular/core';
import { Header } from './components/header/header';
import { Footer } from "./components/footer/footer";
import { TodoForm } from "./components/todoForm/todoForm";
import { Card } from "./components/card/card";
import { CardList } from "./components/cardList/cardList";
import { Carousel } from "./components/carousel/carousel";

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  styleUrl: './app.css',
  imports: [Header, Footer, TodoForm, CardList, Carousel],
})
export class App {}
