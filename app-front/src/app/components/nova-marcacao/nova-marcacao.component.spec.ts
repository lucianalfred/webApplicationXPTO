import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NovaMarcacaoComponent } from './nova-marcacao.component';

describe('NovaMarcacaoComponent', () => {
  let component: NovaMarcacaoComponent;
  let fixture: ComponentFixture<NovaMarcacaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [NovaMarcacaoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(NovaMarcacaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
