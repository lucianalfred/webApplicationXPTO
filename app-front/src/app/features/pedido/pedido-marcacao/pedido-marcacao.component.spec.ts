import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PedidoMarcacaoComponent } from './pedido-marcacao.component';

describe('PedidoMarcacaoComponent', () => {
  let component: PedidoMarcacaoComponent;
  let fixture: ComponentFixture<PedidoMarcacaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PedidoMarcacaoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PedidoMarcacaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
