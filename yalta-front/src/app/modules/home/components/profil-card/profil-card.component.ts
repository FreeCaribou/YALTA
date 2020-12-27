import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-profil-card',
  templateUrl: './profil-card.component.html',
  styleUrls: ['./profil-card.component.scss'],
})
export class ProfilCardComponent implements OnInit {
  @Input()
  profil: any;

  constructor() { }

  ngOnInit() { }

}
