import { Component, OnInit } from '@angular/core';
import { ErrorCommunicationService } from 'src/app/shared/services/communication/error.communication.service';
import { LoaderCommunicationService } from 'src/app/shared/services/communication/loader.communication.service';
import { ProfilService } from 'src/app/shared/services/data/profil/profil.service';

@Component({
  selector: 'app-my-resume',
  templateUrl: './my-resume.component.html',
  styleUrls: ['./my-resume.component.scss'],
})
export class MyResumeComponent implements OnInit {
  profil;

  constructor(
    public profilService: ProfilService,
    public loaderCommunication: LoaderCommunicationService,
    public errorCommunication: ErrorCommunicationService
  ) { }

  ngOnInit() {
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
