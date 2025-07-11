import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PedidoAnonimoComponent } from './pedido-anonimo.component';

describe('PedidoAnonimoComponent', () => {
  let component: PedidoAnonimoComponent;
  let fixture: ComponentFixture<PedidoAnonimoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PedidoAnonimoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PedidoAnonimoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
