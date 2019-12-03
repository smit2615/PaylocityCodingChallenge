import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EmployeeEditComponent } from './employee-edit.component';
import { MaterialModule } from 'src/app/modules/material/material.module';
import { HomeModule } from 'src/app/modules/home/home.module';
import { Dependent } from 'src/app/models/dependent';
import { Employee } from 'src/app/models/employee';
import { EmployeeService } from 'src/app/services/employee.service';
import { SharedModule } from 'src/app/modules/shared/shared.module';
import { Provider } from '@angular/core';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { HttpClient } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { Observable } from 'rxjs';

describe('EmployeeEditComponent', () => {
  let component: EmployeeEditComponent;
  let fixture: ComponentFixture<EmployeeEditComponent>;

  const mockMatDialog = {};
  const mockMatDialogRef = {
    close: (): void => undefined
  };
  const mockMatDialogData = {};
  const mockHttpClient = {};
  const mockEmployeeService = {
    createEmployee: (): Observable<Employee> => new Observable<Employee>(),
    getAllEmployees: (): Observable<Employee[]> => new Observable<Employee[]>()
  };
  
  beforeEach(async(() => {
    
    const mockProviders: Provider[] = [
      { provide: MatDialog, useValue: mockMatDialog },
      {provide: MatDialogRef, useValue: mockMatDialogRef},
      {provide: MAT_DIALOG_DATA, useValue: mockMatDialogData},
      {provide: HttpClient, useValue: mockHttpClient},
      {provide: EmployeeService, useValue: mockEmployeeService}
    ];
    TestBed.configureTestingModule({
      declarations: [ ],
      imports: [HomeModule, SharedModule, BrowserAnimationsModule],
      providers: [mockProviders]
    })
    .compileComponents();

  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EmployeeEditComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  fit('should create', () => {
    expect(component).toBeTruthy();
  });

  fit('should add dependent', () => {
    //Arrange
    let employee = new Employee();
    let dependent = new Dependent();
    dependent.FirstName = 'FirstName';
    dependent.LastName = 'LastName';
    component.dependent = dependent;

    //Act
    component.addDependent();

    //Assert
    expect(component.employee.Dependents.length).toBe(1);
  });

  fit('should not add dependent', () => {
    //Arrange
    let employee = new Employee();
    employee.FirstName = "FirstName";
    employee.LastName = "LastName"; 
    let dependent = new Dependent();
    dependent.FirstName = "FirstName";
    component.dependent = dependent;

    //Act
    component.saveEmployee(false);

    //Assert
    expect(component.employee.Dependents.length).toBe(0);
  });
});
