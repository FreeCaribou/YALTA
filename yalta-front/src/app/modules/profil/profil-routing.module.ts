import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProfilGuard } from 'src/app/shared/guards/profil.guard';
import { MyProfilPage } from './pages/my-profil/my-profil.page';
import { ProfilPage } from './pages/profil/profil.page';

const routes: Routes = [
  {
    path: '',
    component: ProfilPage,
  },
  {
    path: 'my-profil',
    component: MyProfilPage,
    canActivate: [ProfilGuard]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class ProfilPageRoutingModule { }
