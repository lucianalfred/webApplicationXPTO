import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PedidoDetailsComponentComponent } from './pedido-details.component.component';

describe('PedidoDetailsComponentComponent', () => {
  let component: PedidoDetailsComponentComponent;
  let fixture: ComponentFixture<PedidoDetailsComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PedidoDetailsComponentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PedidoDetailsComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
