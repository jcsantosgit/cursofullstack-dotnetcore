import { EventoEditComponent } from './evento/evento-edit/evento-edit.component';
import { NotFoundComponent } from './status-code/app-notfound-component';
import { EventoCreateComponent } from './evento/evento-create/evento-create.component';
import { PainelComponent } from './painel/painel/painel.component';
import { EventoListComponent } from './evento/evento-list/evento-list.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  { path: '', component: PainelComponent},
  { path: 'eventos', component: EventoListComponent },
  { path: 'evento-create', component: EventoCreateComponent},
  { path: 'evento-edit/:id', component: EventoEditComponent},
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
