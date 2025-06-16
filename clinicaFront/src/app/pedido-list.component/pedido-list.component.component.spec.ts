import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PedidoListComponentComponent } from './pedido-list.component.component';

describe('PedidoListComponentComponent', () => {
  let component: PedidoListComponentComponent;
  let fixture: ComponentFixture<PedidoListComponentComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PedidoListComponentComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PedidoListComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
