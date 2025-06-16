import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PedidoFormComponentComponent } from './pedido-form.component.component';

describe('PedidoFormComponentComponent', () => {
  let component: PedidoFormComponentComponent;
  let fixture: ComponentFixture<PedidoFormComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PedidoFormComponentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PedidoFormComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
