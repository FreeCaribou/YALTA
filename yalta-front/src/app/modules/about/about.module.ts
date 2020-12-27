import { NgModule } from '@angular/core';
import { SharedModule } from 'src/app/shared/shared.module';
import { AboutPageRoutingModule } from './about-routing.module';
import { AboutPage } from './about.page';

@NgModule({
  declarations: [AboutPage],
  imports: [
    AboutPageRoutingModule,
    SharedModule
  ]
})
export class AboutPageModule { }
