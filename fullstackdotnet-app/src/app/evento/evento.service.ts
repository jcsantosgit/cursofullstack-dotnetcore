import { Evento } from './../models/Evento';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
@Injectable({
  providedIn: 'root'
})
export class EventoService {

  url = "http://localhost:5000"
  api = "api/evento";

  endpoint = `${this.url}/${this.api}`;

  constructor(private http: HttpClient, private toastr: ToastrService) {

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
      this.http.post(this.endpoint, evento).subscribe(
        () => {this.toastr.success('Evento cadastrado!')}
      );
    } catch (error) {
      console.log(error);
    }
  }

  update(evento: Evento) : void {
    try {
      this.http.put(this.endpoint, evento).subscribe(
        () => {this.toastr.success('Evento alterado!')}
      );
    } catch (error) {
      console.log(error);
    }
  }

  delete(id: number) : void {
    const path = `${this.endpoint}/${id}`;
    this.http.delete(path).subscribe();
  }


  upload(file: FormData) : any {
    console.log(file);
    const path = `${this.url}/api/FileManager/upload`;
    console.log(path);
    const res = this.http.post(path, file).subscribe();
    return res;
  }
}
