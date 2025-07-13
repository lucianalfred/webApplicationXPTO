import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AdministradorNavigationComponent } from './administrador-navigation.component';

describe('AdministradorNavigationComponent', () => {
  let component: AdministradorNavigationComponent;
  let fixture: ComponentFixture<AdministradorNavigationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AdministradorNavigationComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(AdministradorNavigationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
