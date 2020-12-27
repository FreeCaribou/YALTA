import { Component } from '@angular/core';
import { LanguageCommunicationService } from 'src/app/shared/services/communication/language.communication.service';

@Component({
  selector: 'app-profil',
  templateUrl: 'profil.page.html',
  styleUrls: ['profil.page.scss']
})
export class ProfilPage {

  constructor(private languageCommunication: LanguageCommunicationService) { }

}
