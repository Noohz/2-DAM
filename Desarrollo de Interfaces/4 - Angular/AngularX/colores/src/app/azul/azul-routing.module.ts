import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AzulComponent } from './azul.component';

const routes: Routes = [
  {
  path: '',
  component: AzulComponent,
  children: [{ path: 'azul', component: AzulComponent }],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AzulRoutingModule { }
