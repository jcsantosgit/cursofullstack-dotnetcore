import { EventoService } from './../evento.service';
import { Component, OnInit } from '@angular/core';
import { Evento } from 'src/app/models/Evento';

@Component({
  selector: 'app-evento-create',
  templateUrl: './evento-create.component.html',
  styleUrls: ['./evento-create.component.css']
})
export class EventoCreateComponent implements OnInit {

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
  }

  constructor(private service: EventoService) {
   }

  ngOnInit(): void {

  }

  criarEvento() {
    //this.service.create(evento);
    console.log(this.evento);
  }

}
