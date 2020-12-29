import { Component, OnInit } from '@angular/core';
import { ErrorCommunicationService } from 'src/app/shared/services/communication/error.communication.service';
import { LoaderCommunicationService } from 'src/app/shared/services/communication/loader.communication.service';
import { UserCommunicationService } from 'src/app/shared/services/communication/user.communication.service';
import { ProfilService } from 'src/app/shared/services/data/profil/profil.service';

@Component({
  selector: 'app-list-profil',
  templateUrl: './list-profil.component.html',
  styleUrls: ['./list-profil.component.scss'],
})
export class ListProfilComponent implements OnInit {
  profils: any[];

  constructor(
    public loaderCommunication: LoaderCommunicationService,
    public profilService: ProfilService,
    public userCommunication: UserCommunicationService,
    public errorCommunication: ErrorCommunicationService
  ) { }

  ngOnInit() {
    if (this.userCommunication.user) {
      this.loaderCommunication.isLoading = true;
      this.profilService.getSuggestedMatchProfil().subscribe(data => {
        this.profils = data;
      }, error => {
        this.errorCommunication.throwError(error);
      }, () => {
        this.loaderCommunication.isLoading = false;
      })
    }
  }

}
