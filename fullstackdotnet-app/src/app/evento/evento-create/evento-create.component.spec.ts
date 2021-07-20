import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EventoCreateComponent } from './evento-create.component';

describe('EventoCreateComponent', () => {
  let component: EventoCreateComponent;
  let fixture: ComponentFixture<EventoCreateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EventoCreateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EventoCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
