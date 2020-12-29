import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProfilPage } from './pages/profil/profil.page';

const routes: Routes = [
  {
    path: '',
    component: ProfilPage,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProfilPageRoutingModule { }
