import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-list-profil',
  templateUrl: './list-profil.component.html',
  styleUrls: ['./list-profil.component.scss'],
})
export class ListProfilComponent implements OnInit {
  profils: any[];

  constructor() { }

  ngOnInit() {
    this.profils = [
      {
        id: 1,
        name: 'Rosa Luxemburg',
        age: 27,
        description: 'La guerre, c\'est pas très ouf en vrai',
        imageSrc: 'https://www.marxist.com/images/stories/marxists/rosa-luxemburg-90-anniversary-2.jpg',
        sexe: 'f'
      },
      {
        id: 2,
        name: 'Sun Tzu',
        age: 34,
        description: 'La guerre est un art',
        imageSrc: 'https://game-change.com/wp-content/uploads/2014/11/Sun-Tzu-3.jpg',
        sexe: 'm'
      },
      {
        id: 3,
        name: 'Vidkun Quisling',
        age: 47,
        description: 'Si c\'est à refaire je le refait volontier',
        imageSrc: 'https://i.redd.it/2v8pvy7a9m801.jpg',
        sexe: 'm'
      },
      {
        id: 4,
        name: 'Angela Dorothea Kasner',
        age: 19,
        description: 'Wir schaffen das',
        imageSrc: 'https://i0.wp.com/www.teamjimmyjoe.com/wp-content/uploads/2016/04/famous-people-young-german-chancellor-angela-merkel.jpg?resize=640%2C453',
        sexe: 'f'
      },
      {
        id: 5,
        name: 'Leopold II',
        age: 43,
        description: 'Tout ça nous rendra pas le Congo...',
        imageSrc: 'https://cdn.britannica.com/29/133129-050-FC8E1748/Leopold-II.jpg',
        sexe: 'm'
      },
      {
        id: 6,
        name: 'Mobutu Sese Seko',
        age: 31,
        description: 'Ni le Zaïre!',
        imageSrc: 'https://static.guim.co.uk/sys-images/Guardian/Pix/pictures/2013/10/25/1382706596437/Mobutu-Sese-Seko-pictured-010.jpg',
        sexe: 'm'
      },
      {
        id: 7,
        name: 'Louis XVI',
        age: 51,
        description: 'J\'en perd ma tête',
        imageSrc: 'https://www.thefamouspeople.com/profiles/images/louis-xvi-of-france-4.jpg',
        sexe: 'm'
      }
    ]
  }

}
