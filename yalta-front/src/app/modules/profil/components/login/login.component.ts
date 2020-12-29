import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ErrorCommunicationService } from 'src/app/shared/services/communication/error.communication.service';
import { LoaderCommunicationService } from 'src/app/shared/services/communication/loader.communication.service';
import { UserCommunicationService } from 'src/app/shared/services/communication/user.communication.service';
import { UserService } from 'src/app/shared/services/data/user/user.service';
import { emailValidPattern } from 'src/app/shared/utils';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  newAccount = false;

  constructor(
    public formBuilder: FormBuilder,
    public userService: UserService,
    public userCommunication: UserCommunicationService,
    public loaderCommunication: LoaderCommunicationService,
    public errorCommunication: ErrorCommunicationService,
    public router: Router
  ) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      // TODO better email pattern
      email: [environment.mock ? 'samy@yetanotherlovetreatyapp.com' : '', [Validators.required, Validators.pattern(emailValidPattern)]],
      password: [environment.mock ? 'babyDontHurtMeNoMore' : '', Validators.required],
      name: [environment.mock ? 'Samy Gnu' : '']
    })
  }

  onLogin() {
    this.loaderCommunication.isLoading = true;
    this.userService.login(this.loginForm.value).subscribe((data: any) => {
      // TODO better form the data
      console.log('the login data', data);
      this.userCommunication.user = data;
    }, error => {
      this.errorCommunication.throwError(error);
    }, () => {
      this.loaderCommunication.isLoading = false;
    })
  }

  onSignUp() {
    this.userService.signUp(this.loginForm.value).subscribe((data: any) => {
      // TODO better form the data
      console.log('the sign up data', data);
      this.userCommunication.user = data;
      // TODO describe better profil now?
      this.router.navigate(['tabs/profil/my-profil']);
    }, error => {
      this.errorCommunication.throwError(error);
    }, () => {
      this.loaderCommunication.isLoading = false;
    })
  }

}