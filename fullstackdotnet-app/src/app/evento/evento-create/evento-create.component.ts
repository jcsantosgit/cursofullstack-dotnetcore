import { Observable, Subscriber } from 'rxjs';
import { EventoService } from './../evento.service';
import { Component, OnInit } from '@angular/core';
import { Evento } from 'src/app/models/Evento';

import { ImageCroppedEvent } from 'ngx-image-cropper';
import { Router } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';

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
  registerForm: FormGroup = new FormGroup({});

  constructor(private service: EventoService, private router: Router) {
    this.foto = "../../assets/images/indisponivel.jpg";
  }

  ngOnInit(): void {
    this.formInit();
  }

  formInit () {
    this.registerForm = new FormGroup({
      local: new FormControl('', [Validators.required, Validators.maxLength(100)]),
      dataEvento: new FormControl('', [Validators.required]),
      tema: new FormControl('', Validators.required),
      qtdPublico: new FormControl('', [Validators.required, Validators.min(10), Validators.max(100)]),
      imageUrl: new FormControl('', Validators.required),
      telefone: new FormControl('', [Validators.required, Validators.min(11), Validators.max(11)]),
      email: new FormControl('', [Validators.required, Validators.email]),
      lotes: new FormControl('', Validators.required),
      redesSociais: new FormControl('', Validators.required),
      palestrantesEventos : new FormControl('', Validators.required),
      includePalestrantes: new FormControl('', Validators.required)
    })
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
