import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: 'home.page.html',
  styleUrls: ['home.page.scss']
})
export class HomePage {
  quotes = [
    'La Pologne, c\'est à deux qu\'elle s\'envahit',
    'Partionnons l\'Allemagne vaincu ensemble',
    'Laisse moi te fournir ma démocratie'
  ];
  quote: string;

  constructor() { }

  ionViewWillEnter() {
    this.quote = this.getRandomQuote();
  }

  getRandomQuote(): string {
    return this.quotes[Math.floor((Math.random() * this.quotes.length))];
  }

}
