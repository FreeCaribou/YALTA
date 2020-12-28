import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserCommunicationService } from 'src/app/shared/services/communication/user.communication.service';
import { UserService } from 'src/app/shared/services/data/user/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'],
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  newAccount = false;

  constructor(
    private formBuilder: FormBuilder,
    private userService: UserService,
    private userCommunication: UserCommunicationService
  ) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      // TODO better email pattern
      email: ['', [Validators.required, Validators.pattern(/^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/)]],
      password: ['', Validators.required],
      name: ['']
    })
  }

  onLogin() {
    this.userService.login(this.loginForm.value).subscribe((data: any) => {
      // TODO better form the data
      console.log('the login data', data);
      this.userCommunication.user = data;
    })
  }

  onSignUp() {
    this.userService.signUp(this.loginForm.value).subscribe((data: any) => {
      // TODO better form the data
      console.log('the sign up data', data);
      this.userCommunication.user = data;
      // TODO describe better profil now?
    })
  }

}