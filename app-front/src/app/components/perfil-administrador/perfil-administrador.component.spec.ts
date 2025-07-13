import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PerfilAdministradorComponent } from './perfil-administrador.component';

describe('PerfilAdministradorComponent', () => {
  let component: PerfilAdministradorComponent;
  let fixture: ComponentFixture<PerfilAdministradorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PerfilAdministradorComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PerfilAdministradorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
