import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeachMenuComponent } from './teach-menu.component';

describe('TeachMenuComponent', () => {
  let component: TeachMenuComponent;
  let fixture: ComponentFixture<TeachMenuComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TeachMenuComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TeachMenuComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
