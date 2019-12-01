import { Component, OnInit } from '@angular/core';
import { Employee } from 'src/app/models/employee';
import { EmployeeService } from 'src/app/services/employee.service';
import { Observable, BehaviorSubject } from 'rxjs';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  employees: BehaviorSubject<Employee[]>;

  constructor(private _employeeService: EmployeeService) { }

  async ngOnInit() {
    this.employees = await this._employeeService.getAllEmployees();
  }

}
