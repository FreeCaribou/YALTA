import { NgModule } from '@angular/core';
import { ProfilPage } from './pages/profil/profil.page';

import { ProfilPageRoutingModule } from './profil-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { LoginComponent } from './components/login/login.component';
import { MyResumeComponent } from './components/my-resume/my-resume.component';
import { MyProfilPage } from './pages/my-profil/my-profil.page';

@NgModule({
  imports: [
    ProfilPageRoutingModule,
    SharedModule,
  ],
  declarations: [ProfilPage, MyProfilPage, LoginComponent, MyResumeComponent]
})
export class ProfilPageModule { }
