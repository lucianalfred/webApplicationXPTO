import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministradorUtilizadoresComponent } from './administrador-utilizadores.component';

describe('AdministradorUtilizadoresComponent', () => {
  let component: AdministradorUtilizadoresComponent;
  let fixture: ComponentFixture<AdministradorUtilizadoresComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdministradorUtilizadoresComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AdministradorUtilizadoresComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
