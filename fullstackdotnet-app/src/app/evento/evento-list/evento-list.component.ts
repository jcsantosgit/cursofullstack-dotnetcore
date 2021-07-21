import { EventoService } from '../evento.service';
import { Component, OnInit } from '@angular/core';
import { Evento } from 'src/app/models/Evento';

@Component({
  selector: 'app-evento-list',
  templateUrl: './evento-list.component.html',
  styleUrls: ['./evento-list.component.css']
})
export class EventoListComponent implements OnInit {

  eventos: Evento[] = [];

  constructor(private service: EventoService) { }

  ngOnInit(): void {
    this.service.listar().subscribe(
      eventos => {
        this.eventos = eventos
        console.log(eventos)
      }
    )
  }

}
