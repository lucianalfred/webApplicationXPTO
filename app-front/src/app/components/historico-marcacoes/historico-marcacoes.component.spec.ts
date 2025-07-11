import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HistoricoMarcacoesComponent } from './historico-marcacoes.component';

describe('HistoricoMarcacoesComponent', () => {
  let component: HistoricoMarcacoesComponent;
  let fixture: ComponentFixture<HistoricoMarcacoesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [HistoricoMarcacoesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HistoricoMarcacoesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
