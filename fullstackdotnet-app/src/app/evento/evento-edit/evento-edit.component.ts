import { EventoService } from './../evento.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Evento } from 'src/app/models/Evento';

@Component({
  selector: 'app-evento-edit',
  templateUrl: './evento-edit.component.html',
  styleUrls: ['./evento-edit.component.css']
})
export class EventoEditComponent implements OnInit {

  eventoId?: number;

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

  constructor(private activatedRoute: ActivatedRoute, private service: EventoService) { }

  ngOnInit(): void {
    var id = this.activatedRoute.snapshot.params['id'];
    this.eventoId =  Number.parseInt(id);
    this.service.searchById(this.eventoId).subscribe(
      e => this.evento = e
    );
  }

  salvar(){
    console.log("salvar");
  }
}
