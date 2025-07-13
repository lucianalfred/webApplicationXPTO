import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PerfilAdministrativoComponent } from './perfil-administrativo.component';

describe('PerfilAdministrativoComponent', () => {
  let component: PerfilAdministrativoComponent;
  let fixture: ComponentFixture<PerfilAdministrativoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PerfilAdministrativoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PerfilAdministrativoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
