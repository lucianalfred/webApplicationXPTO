import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministrativoNavigationComponent } from './administrativo-navigation.component';

describe('AdministrativoNavigationComponent', () => {
  let component: AdministrativoNavigationComponent;
  let fixture: ComponentFixture<AdministrativoNavigationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdministrativoNavigationComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AdministrativoNavigationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
