import { Component } from '@angular/core';
import { Card } from '../card/card';
import { FormsModule } from '@angular/forms';

@Component({
  templateUrl: './todoForm.html',
  selector: 'app-todoForm',
  styleUrl: './todoForm.css',
  imports: [FormsModule],
})
export class TodoForm {
  card: Card = new Card();
  todoList: Card[] = [];

  // getTitle(e: Event) {
  //   let elem = e.target as HTMLInputElement;
  //   this.card.title = elem.value;
  // }
  // getDescription(e: Event) {
  //   let elem = e.target as HTMLInputElement;
  //   this.card.description = elem.value;
  // }
  // getPriority(e: Event) {
  //   let elem = e.target as HTMLInputElement;
  //   this.card.priority = elem.value;
  // }
  // getCategory(e: Event) {
  //   let elem = e.target as HTMLInputElement;
  //   this.card.category = elem.value;
  // }
  // getTag(e: Event) {
  //   let elem = e.target as HTMLInputElement;
  //   this.card.tag = elem.value;
  // }
  // getDate(e: Event) {
  //   let elem = e.target as HTMLInputElement;
  //   this.card.date = elem.value;
  // }

  saveData() {
    this.todoList.push(this.card);
    console.log(this.todoList);
    this.card = new Card();
  }
}
