import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministrativoPedidosComponent } from './administrativo-pedidos.component';

describe('AdministrativoPedidosComponent', () => {
  let component: AdministrativoPedidosComponent;
  let fixture: ComponentFixture<AdministrativoPedidosComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdministrativoPedidosComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AdministrativoPedidosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
