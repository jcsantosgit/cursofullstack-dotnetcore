import { Evento } from './../models/Evento';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ToastrService } from 'ngx-toastr';
@Injectable({
  providedIn: 'root'
})
export class EventoService {

  url = "http://localhost:5000";
  controller = "api/Evento";

  constructor(private http: HttpClient, private toastr: ToastrService) {

  }

  searchById(id: number) : Observable<Evento> {
    const endpoint = `${this.url}/${this.controller}/search-by-id/${id}`;
    return this.http.get<Evento>(endpoint);
  }

  list(): Observable<Evento[]> {
    try {
      const endpoint = `${this.url}/${this.controller}/list`
      return this.http.get<Evento[]>(endpoint);
    } catch (error) {
      console.log(error);
      throw error;
    }
  }

  create(evento: Evento) : void {
    try {
      const endpoint = `${this.url}/${this.controller}/create`
      this.http.post(endpoint, evento).subscribe(
        () => {this.toastr.success('Evento cadastrado!')}
      );
    } catch (error) {
      console.log(error);
    }
  }

  update(evento: Evento) : void {
    try {
      const endpoint = `${this.url}/${this.controller}/update`
      this.http.put(endpoint, evento).subscribe(
        () => {this.toastr.success('Evento alterado!')}
      );
    } catch (error) {
      console.log(error);
    }
  }

  delete(id: number) : Observable<any> {
    const endpoint = `${this.url}/${this.controller}/remove/${id}`;
    console.log('exclusão');
    console.log(endpoint);
    return this.http.delete(endpoint);
  }

  upload(file: FormData) : any {
    const path = `${this.url}/filemanager/upload`;
    const res = this.http.post(path, file).subscribe();
    return res;
  }

}
