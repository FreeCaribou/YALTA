import { Component } from '@angular/core';
import { ErrorCommunicationService } from 'src/app/shared/services/communication/error.communication.service';
import { LoaderCommunicationService } from 'src/app/shared/services/communication/loader.communication.service';
import { ProfilService } from 'src/app/shared/services/data/profil/profil.service';

@Component({
  selector: 'app-my-profil',
  templateUrl: 'my-profil.page.html',
  styleUrls: ['my-profil.page.scss']
})
export class MyProfilPage {
  profil;

  constructor(
    private profilService: ProfilService,
    private loaderCommunication: LoaderCommunicationService,
    private errorCommunication: ErrorCommunicationService
  ) { }

  ionViewWillEnter() {
    this.loaderCommunication.isLoading = true;
    this.profilService.getMyProfil().subscribe(data => {
      this.profil = data;
    }, error => {
      this.errorCommunication.throwError(error);
    }, () => {
      this.loaderCommunication.isLoading = false;
    })
  }

}
