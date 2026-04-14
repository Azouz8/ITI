import { Component } from '@angular/core';
import { Header } from './components/header/header';
import { Footer } from "./components/footer/footer";
import { TodoForm } from "./components/todoForm/todoForm";
import { Card } from "./components/card/card";
import { CardList } from "./components/cardList/cardList";

@Component({
  selector: 'app-root',
  templateUrl: './app.html',
  styleUrl: './app.css',
  imports: [Header, Footer, TodoForm, CardList],
})
export class App {}
