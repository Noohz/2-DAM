import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AzulRoutingModule } from './azul-routing.module';
import { AzulComponent } from './azul.component';


@NgModule({
  declarations: [
    AzulComponent
  ],
  imports: [
    CommonModule,
    AzulRoutingModule
  ]
})
export class AzulModule { }
