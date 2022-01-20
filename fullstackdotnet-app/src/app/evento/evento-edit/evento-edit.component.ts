import { Observable, Subscriber } from 'rxjs';
import { EventoService } from './../evento.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Evento } from 'src/app/models/Evento';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-evento-edit',
  templateUrl: './evento-edit.component.html',
  styleUrls: ['./evento-edit.component.css']
})
export class EventoEditComponent implements OnInit {

  eventoId?: number;
  foto: string = "";
  evento: Evento;
  registerForm: FormGroup = new FormGroup({});

  constructor(
    private activatedRoute: ActivatedRoute,
    private service: EventoService,
    private router: Router) { }

  ngOnInit(): void {

    var id = this.activatedRoute.snapshot.params['id'];
    this.eventoId =  Number.parseInt(id);
    this.service.searchById(this.eventoId).subscribe(
      e => {
        console.log(e);
        this.evento = e;
        this.foto = e.imageUrl;
      }
    );

    this.formInit();
  }

  formInit () {
    this.registerForm = new FormGroup({
      local: new FormControl('', [Validators.required, Validators.maxLength(100)]),
      dataEvento: new FormControl('', [Validators.required]),
      tema: new FormControl('', Validators.required),
      qtdPublico: new FormControl('', [Validators.required, Validators.min(10), Validators.max(100)]),
      telefone: new FormControl('', [Validators.required, Validators.maxLength(11)]),
      email: new FormControl('', [Validators.required, Validators.email]),
      conteudo: new FormControl('', [Validators.required])
    })
  }

  salvar(){
    this.evento.imageUrl = this.foto;
    this.service.update(this.evento);
    console.log("salvar");
  }

  cancel() : void {
    this.foto = "";
    this.router.navigate(['/eventos'])
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
