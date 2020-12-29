import { NgModule } from '@angular/core';
import { ProfilPage } from './pages/profil/profil.page';

import { ProfilPageRoutingModule } from './profil-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { LoginComponent } from './components/login/login.component';

@NgModule({
  imports: [
    ProfilPageRoutingModule,
    SharedModule,
  ],
  declarations: [ProfilPage, LoginComponent]
})
export class ProfilPageModule { }
