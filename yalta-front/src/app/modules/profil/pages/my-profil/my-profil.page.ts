import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ErrorCommunicationService } from 'src/app/shared/services/communication/error.communication.service';
import { LoaderCommunicationService } from 'src/app/shared/services/communication/loader.communication.service';
import { ProfilService } from 'src/app/shared/services/data/profil/profil.service';

@Component({
  selector: 'app-my-profil',
  templateUrl: 'my-profil.page.html',
  styleUrls: ['my-profil.page.scss']
})
export class MyProfilPage implements OnInit {
  profil;
  profilForm: FormGroup;
  hatedPersonalitiesForm: FormGroup;
  lovedPersonalitiesForm: FormGroup;

  constructor(
    public profilService: ProfilService,
    public loaderCommunication: LoaderCommunicationService,
    public errorCommunication: ErrorCommunicationService,
    public formBuilder: FormBuilder,
  ) { }

  ngOnInit(): void {
    this.loaderCommunication.isLoading = true;
    this.profilService.getMyProfil().subscribe(data => {
      this.profil = data;
      this.initFormData();
    }, error => {
      this.errorCommunication.throwError(error);
    }, () => {
      this.loaderCommunication.isLoading = false;
    })
  }

  initFormData() {
    this.profilForm = this.formBuilder.group({
      name: [this.profil.name, Validators.required],
      sexe: [this.profil.sexe, Validators.required],
      lovedPersonalities: []
    });

    this.hatedPersonalitiesForm = this.formBuilder.group({
      one: [this.profil.hatedPersonalities[0] || ''],
      two: [this.profil.hatedPersonalities[1] || ''],
      three: [this.profil.hatedPersonalities[2] || ''],
      four: [this.profil.hatedPersonalities[3] || ''],
      five: [this.profil.hatedPersonalities[4] || '']
    });

    this.lovedPersonalitiesForm = this.formBuilder.group({
      one: [this.profil.lovedPersonalities[0] || ''],
      two: [this.profil.lovedPersonalities[1] || ''],
      three: [this.profil.lovedPersonalities[2] || ''],
      four: [this.profil.lovedPersonalities[3] || ''],
      five: [this.profil.lovedPersonalities[4] || '']
    });
  }

  onEdit() {
    // TODO
    console.log(this.profilForm, this.hatedPersonalitiesForm, this.lovedPersonalitiesForm);
  }

}
