import { Evento } from './../models/Evento';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class EventoService {

  baseUrl = "http://localhost:5000/api/evento";

  constructor(private http: HttpClient) {

  }

  listar(): Observable<Evento[]> {
    try {
      return this.http.get<Evento[]>(this.baseUrl);
    } catch (error) {
      console.log(error);
      throw error;
    }
  }

  create(evento: Evento) : void {
    try {
      this.http.post(this.baseUrl, evento);
    } catch (error) {
      console.log(error);
    }
  }
}
