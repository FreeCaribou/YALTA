import { Component, Input, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';

@Component({
  selector: 'app-personalities-list-form',
  templateUrl: './personalities-list-form.component.html',
  styleUrls: ['./personalities-list-form.component.scss'],
})
export class PersonalitiesListFormComponent implements OnInit {
  @Input()
  form: FormGroup;
  @Input()
  title: string;

  constructor() { }

  ngOnInit() { }

}
