import { Evento } from './../models/Evento';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class EventoService {

  url = "http://localhost:5000"
  api = "api/evento";

  endpoint = `${this.url}/${this.api}`;

  constructor(private http: HttpClient) {

  }

  searchById(id: number) : Observable<Evento> {
    const path = `${this.endpoint}/${id}/false`;
    return this.http.get<Evento>(path);
  }

  listar(): Observable<Evento[]> {
    try {
      return this.http.get<Evento[]>(this.endpoint);
    } catch (error) {
      console.log(error);
      throw error;
    }
  }

  create(evento: Evento) : void {
    try {
      this.http.post(this.endpoint, evento).subscribe();
    } catch (error) {
      console.log(error);
    }
  }

  upload(file: FormData) : any {
    console.log(file);
    const path = `${this.url}/api/FileManager/upload`;
    console.log(path);
    const res = this.http.post(path, file).subscribe();
    return res;
  }
}
