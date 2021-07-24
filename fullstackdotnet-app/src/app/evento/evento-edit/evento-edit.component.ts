import { Component, OnInit } from '@angular/core';
import { Evento } from 'src/app/models/Evento';

@Component({
  selector: 'app-evento-edit',
  templateUrl: './evento-edit.component.html',
  styleUrls: ['./evento-edit.component.css']
})
export class EventoEditComponent implements OnInit {

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

  constructor() { }

  ngOnInit(): void {
  }

  salvar(){
    console.log("salvar");
  }

}
