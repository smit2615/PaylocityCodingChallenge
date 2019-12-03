import { Component, OnInit, Input } from '@angular/core';
import { Employee } from 'src/app/models/employee';
import { EmployeeEditComponent } from '../employee-edit/employee-edit.component';
import { MatDialog } from '@angular/material/dialog'

@Component({
  selector: 'app-employee-entry',
  templateUrl: './employee-entry.component.html',
  styleUrls: ['./employee-entry.component.css']
})
export class EmployeeEntryComponent implements OnInit {

  @Input() employees: Employee[]

  constructor(public dialog: MatDialog) { }

  ngOnInit() {
  }

  openEditModal(employee: Employee) {
    if(employee === undefined) {
      employee = new Employee();
    }
    
    let modalRef = this.dialog.open(EmployeeEditComponent,
      {
        data: { 
          firstName: employee.FirstName, lastName: employee.LastName,
          dependents: employee.Dependents, annualCost: employee.AnnualCost
        }
      });
  }

}
