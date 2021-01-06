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
  firstPreferredPeriodForm: FormGroup;
  secondPreferredPeriodForm: FormGroup;
  thirdPreferredPeriodForm: FormGroup;

  year = new Date().getFullYear();
  profil;
  historyRanges;
  geographicalAreas;
  numberOfHistoryRange = 1;

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

    // TODO see with the backend the already existing value
    this.firstPreferredPeriodForm = this.formCommunication.buildPreferredPeriodForm(-1000, this.year, []);
    this.secondPreferredPeriodForm = this.formCommunication.buildPreferredPeriodForm(-1000, this.year, []);
    this.thirdPreferredPeriodForm = this.formCommunication.buildPreferredPeriodForm(-1000, this.year, []);
  }

  onAddPeriod(event) {
    this.numberOfHistoryRange += 1;
  }

  onRemoveFirstPeriod(event) {
    if (this.numberOfHistoryRange == 3) {
      this.firstPreferredPeriodForm = this.secondPreferredPeriodForm;
      this.secondPreferredPeriodForm = this.thirdPreferredPeriodForm;
      this.thirdPreferredPeriodForm = this.formCommunication.buildPreferredPeriodForm(-1000, this.year, []);
    }
    else if (this.numberOfHistoryRange == 2) {
      this.firstPreferredPeriodForm = this.secondPreferredPeriodForm;
      this.secondPreferredPeriodForm = this.formCommunication.buildPreferredPeriodForm(-1000, this.year, []);
    }
    this.numberOfHistoryRange -= 1;
  }

  onRemoveSecondPeriod(event) {
    if (this.numberOfHistoryRange == 3) {
      this.secondPreferredPeriodForm = this.thirdPreferredPeriodForm;
      this.thirdPreferredPeriodForm = this.formCommunication.buildPreferredPeriodForm(-1000, this.year, []);
    }
    this.numberOfHistoryRange -= 1;
  }

  onRemoveThirdPeriod(event) {
    this.thirdPreferredPeriodForm = this.formCommunication.buildPreferredPeriodForm(-1000, this.year, []);
    this.numberOfHistoryRange -= 1;
  }

  onEdit() {
    // TODO
    let preferredPeriods = [this.firstPreferredPeriodForm.value];
    if (this.numberOfHistoryRange >= 2) {
      preferredPeriods.push(this.secondPreferredPeriodForm.value);
    }
    if (this.numberOfHistoryRange >= 3) {
      preferredPeriods.push(this.thirdPreferredPeriodForm.value);
    }

    let profilToReturn = this.profilForm.value;
    profilToReturn.hatedPersonalities = this.hatedPersonalitiesForm.value;
    profilToReturn.lovedPersonalities = this.lovedPersonalitiesForm.value;
    profilToReturn.preferredPeriods = preferredPeriods;

    console.log('the profil', profilToReturn);
  }

}
