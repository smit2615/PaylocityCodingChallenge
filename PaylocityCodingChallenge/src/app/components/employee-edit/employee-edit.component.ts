import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Employee } from 'src/app/models/employee';
import { inject } from '@angular/core/testing';
import { EmployeeService } from 'src/app/services/employee.service';
import { Dependent } from 'src/app/models/dependent';

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

  saveEmployee() {
    if(this.dependent.FirstName && this.dependent.LastName) {
      this.employee.Dependents.push(this.dependent);
    }
    
    this.employeeService.createEmployee(this.employee)
      .subscribe(x => this.employeeService.getAllEmployees());
    this.close();
  }

  addDependent() {
    this.employee.Dependents.push(this.dependent);
    this.dependent = new Dependent();
  }

}
