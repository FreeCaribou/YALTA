import { Component, OnInit } from '@angular/core';
import { FormGroup } from '@angular/forms';
import { forkJoin } from 'rxjs';
import { ErrorCommunicationService } from 'src/app/shared/services/communication/error.communication.service';
import { FormCommunicationService } from 'src/app/shared/services/communication/form.communication.service';
import { LoaderCommunicationService } from 'src/app/shared/services/communication/loader.communication.service';
import { ProfilService } from 'src/app/shared/services/data/profil/profil.service';
import { ToolService } from 'src/app/shared/services/data/tool/tool.service';

@Component({
  selector: 'app-my-profil',
  templateUrl: 'my-profil.page.html',
  styleUrls: ['my-profil.page.scss']
})
export class MyProfilPage implements OnInit {
  profilForm: FormGroup;
  hatedPersonalitiesForm: FormGroup;
  lovedPersonalitiesForm: FormGroup;
  preferredPeriodForm: FormGroup;

  year = new Date().getFullYear();
  profil;
  historyRanges;
  geographicalAreas;

  constructor(
    public profilService: ProfilService,
    public loaderCommunication: LoaderCommunicationService,
    public errorCommunication: ErrorCommunicationService,
    public toolService: ToolService,
    public formCommunication: FormCommunicationService
  ) { }

  ngOnInit(): void {
    this.loaderCommunication.isLoading = true;
    forkJoin([
      this.profilService.getMyProfil(),
      this.toolService.getHistoryRanges(),
      this.toolService.getGeographicalAreas(),
    ]).subscribe(datas => {
      this.profil = datas[0];
      this.historyRanges = datas[1];
      this.geographicalAreas = datas[2];
      this.initFormData();
    }, error => {
      this.errorCommunication.throwError(error);
    }, () => {
      this.loaderCommunication.isLoading = false;
    })
  }

  initFormData() {
    this.profilForm = this.formCommunication.buildProfilForm(this.profil);
    this.hatedPersonalitiesForm = this.formCommunication.buildPersonalitiesForm(this.profil.hatedPersonalities);
    this.lovedPersonalitiesForm = this.formCommunication.buildPersonalitiesForm(this.profil.lovedPersonalities);
    this.preferredPeriodForm = this.formCommunication.buildPreferredPeriodForm(478, 1831, []);
  }

  onEdit() {
    // TODO
    console.log(this.profilForm, this.preferredPeriodForm, this.hatedPersonalitiesForm, this.lovedPersonalitiesForm);
  }

}
