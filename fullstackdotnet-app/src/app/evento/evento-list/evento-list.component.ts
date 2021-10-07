import { Router } from '@angular/router';
import { EventoService } from '../evento.service';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { Evento } from 'src/app/models/Evento';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-evento-list',
  templateUrl: './evento-list.component.html',
  styleUrls: ['./evento-list.component.css']
})
export class EventoListComponent implements OnInit {

  eventos: Evento[] = [];
  modalRef: BsModalRef = new BsModalRef();
  message: string = "";
  id: number = 0;

  constructor(
    private service: EventoService,
    private modalService: BsModalService,
    private router: Router
    ) { }

  ngOnInit(): void {
    this.service.list().subscribe(
      eventos => {
        this.eventos = eventos
      }
    )
  }

  openModal($event: any, template: TemplateRef<any>) {
    this.id = $event.target.id;
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.message = 'Confirmed!';
    this.modalRef.hide();
    this.service.delete(this.id);
    this.ngOnInit();
  }

  decline(): void {
    this.message = 'Declined!';
    this.id = 0;
    this.modalRef.hide();
  }

}
