import { Injectable } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { TranslateService } from '@ngx-translate/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { emailValidPattern } from '../../utils';

@Injectable({
  providedIn: 'root'
})
export class FormCommunicationService {

  constructor(
    public formBuilder: FormBuilder
  ) { }

  buildProfilForm(profil) {
    return this.formBuilder.group({
      name: [profil.name, Validators.required],
      sexe: [profil.sexe, Validators.required],
      description: [profil.description]
    });
  }

  buildPreferredPeriodForm(lower: number, upper: number, areas: any[]) {
    return this.formBuilder.group({
      // TODO better control for it
      range: [{ lower, upper }],
      areas: [areas]
    });
  }

  buildPersonalitiesForm(personalities: any) {
    return this.formBuilder.group({
      first: [personalities.first || ''],
      second: [personalities.second || ''],
      third: [personalities.third || ''],
      fourth: [personalities.fourth || ''],
      fifth: [personalities.fifth || '']
    });
  }

  buildLoginForm() {
    return this.formBuilder.group({
      email: [environment.mock ? 'samy@yetanotherlovetreatyapp.com' : '', [Validators.required, Validators.pattern(emailValidPattern)]],
      password: [environment.mock ? 'babyDontHurtMeNoMore' : '', Validators.required],
      name: [environment.mock ? 'Samy Gnu' : '']
    });
  }

}