import { NgModule } from '@angular/core';

import { HomePageRoutingModule } from './home-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { ProfilCardComponent } from './components/profil-card/profil-card.component';
import { ListProfilComponent } from './components/list-profil/list-profil.component';
import { HomePage } from './pages/home/home.page';

@NgModule({
  imports: [
    HomePageRoutingModule,
    SharedModule,
  ],
  declarations: [HomePage, ProfilCardComponent, ListProfilComponent]
})
export class HomePageModule { }
