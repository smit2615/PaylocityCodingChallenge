import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeEntryComponent } from './employee-entry.component';
import { AppModule } from 'src/app/app.module';
import { HomeModule } from 'src/app/modules/home/home.module';

describe('EmployeeEntryComponent', () => {
  let component: EmployeeEntryComponent;
  let fixture: ComponentFixture<EmployeeEntryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ],
      imports: [ HomeModule ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeEntryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  fit('should create', () => {
    expect(component).toBeTruthy();
  });
});
