import { Observable, Subscriber } from 'rxjs';
import { EventoService } from './../evento.service';
import { Component, OnInit } from '@angular/core';
import { Evento } from 'src/app/models/Evento';

import { ImageCroppedEvent } from 'ngx-image-cropper';
import { Router } from '@angular/router';

@Component({
  selector: 'app-evento-create',
  templateUrl: './evento-create.component.html',
  styleUrls: ['./evento-create.component.css']
})
export class EventoCreateComponent implements OnInit {

  foto = ""

  evento: Evento = {
    local:"",
    dataEvento: new Date(),
    tema: "",
    qtdPublico: 0,
    imageUrl: "../../assets/images/indisponivel.jpg",
    telefone: "",
    email: "",
    lotes: [],
    redesSociais: [],
    palestrantesEventos : [],
    includePalestrantes: false
  };

  constructor(private service: EventoService, private router: Router) {
    this.foto = "../../assets/images/indisponivel.jpg";
   }

  ngOnInit(): void {

  }

  criarEvento() {
    this.evento.imageUrl = this.foto;
    this.service.create(this.evento);
    this.cancel();
  }

  cancel() : void {
    this.foto = "../../assets/images/indisponivel.jpg";
    this.router.navigate(['/eventos']);
  }

  onChange(event: any) {

    if(event.target.files && event.target.files[0]) {
      const file = event.target.files[0];
      this.convertToBase64(file);
    }
  }

  convertToBase64(file: File){
    const observable = new Observable((subscriber: Subscriber<any>)=>{
      this.readFile(file, subscriber);
    });
    observable.subscribe((f)=>{
      this.foto = f;
    })
  }

  readFile(file: File, subscriber: Subscriber<any>){
    const filereader = new FileReader();
    filereader.readAsDataURL(file);

    filereader.onload=()=>{
      subscriber.next(filereader.result);
      subscriber.complete();
    }

    filereader.onerror=(error)=>{
      subscriber.error(error);
      subscriber.complete();
    }
  }
}
