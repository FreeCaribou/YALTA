import { Component } from '@angular/core';
import { LanguageCommunicationService } from 'src/app/shared/services/communication/language.communication.service';
import { UserCommunicationService } from 'src/app/shared/services/communication/user.communication.service';

@Component({
  selector: 'app-profil',
  templateUrl: 'profil.page.html',
  styleUrls: ['profil.page.scss']
})
export class ProfilPage {

  constructor(
    public languageCommunication: LanguageCommunicationService,
    public userCommunication: UserCommunicationService
  ) { }

  disconnect() {
    this.userCommunication.user = null;
  }
}
