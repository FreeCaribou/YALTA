import { NgModule } from '@angular/core';
import { ProfilPage } from './profil.page';

import { ProfilPageRoutingModule } from './profil-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';

@NgModule({
  imports: [
    ProfilPageRoutingModule,
    SharedModule,
  ],
  declarations: [ProfilPage]
})
export class ProfilPageModule { }
