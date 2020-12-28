import { NgModule } from '@angular/core';
import { IonicModule } from '@ionic/angular';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { TranslateModule } from '@ngx-translate/core';
import { HeaderComponent } from './components/header/header.component';
import { TemplateCenterColComponent } from './components/template-center-col/template-center-col.component';

@NgModule({
  declarations: [HeaderComponent, TemplateCenterColComponent],
  imports: [
    CommonModule,
    IonicModule,
    FormsModule,
    ReactiveFormsModule,
    TranslateModule,
  ],
  exports: [IonicModule, CommonModule, ReactiveFormsModule, FormsModule, TranslateModule, HeaderComponent, TemplateCenterColComponent]
})
export class SharedModule { }
