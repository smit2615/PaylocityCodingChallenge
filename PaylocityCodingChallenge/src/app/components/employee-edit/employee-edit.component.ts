import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Employee } from 'src/app/models/employee';
import { inject } from '@angular/core/testing';
import { EmployeeService } from 'src/app/services/employee.service';
import { Dependent } from 'src/app/models/dependent';
import { StepperSelectionEvent } from '@angular/cdk/stepper';

@Component({
  selector: 'app-employee-edit',
  templateUrl: './employee-edit.component.html',
  styleUrls: ['./employee-edit.component.css']
})
export class EmployeeEditComponent implements OnInit {

  employee: Employee;
  dependent: Dependent;

  constructor(
    public dialogRef: MatDialogRef<EmployeeEditComponent>,
    @Inject(MAT_DIALOG_DATA) public data: Employee,
    private employeeService: EmployeeService) {
      this.employee = data;
      if(this.employee.Dependents === undefined) {
        this.employee.Dependents = []
      }
      this.dependent = new Dependent();
    }

  ngOnInit() {

  }

  close(): void {
    this.dialogRef.close();
  }

  saveEmployee(continueAdding: boolean) {
      if(this.dependent.FirstName.length > 0 && this.dependent.LastName.length > 0) {
        this.employee.Dependents.push(this.dependent);
      }
      
      this.employeeService.createEmployee(this.employee)
        .subscribe(x => this.employeeService.getAllEmployees());

      if(continueAdding) {
        this.reset();
      }
      else {
        this.close();
      }
  }

  addDependent() {
    this.employee.Dependents.push(this.dependent);
    this.dependent = new Dependent();
  }

  reset() {
    
    this.employee = new Employee();
    this.dependent = new Dependent();
  }

}
