import { NotFoundComponent } from './status-code/app-notfound-component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { EventoListComponent } from './evento/evento-list/evento-list.component';
import { PainelComponent } from './painel/painel/painel.component';

import { HttpClientModule } from '@angular/common/http';
import { EventoCreateComponent } from './evento/evento-create/evento-create.component';

import { FormsModule } from '@angular/forms';
import { EventoEditComponent } from './evento/evento-edit/evento-edit.component';

@NgModule({
  declarations: [
    AppComponent,
    EventoListComponent,
    PainelComponent,
    EventoCreateComponent,
    NotFoundComponent,
    EventoEditComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
