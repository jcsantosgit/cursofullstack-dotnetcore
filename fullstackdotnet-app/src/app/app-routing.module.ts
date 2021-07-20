import { EventoCreateComponent } from './evento/evento-create/evento-create.component';
import { PainelComponent } from './painel/painel/painel.component';
import { EventoListComponent } from './evento/evento-list/evento-list.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', component: PainelComponent},
  { path: 'Eventos', component: EventoListComponent },
  { path: 'EventoCreate', component: EventoCreateComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
