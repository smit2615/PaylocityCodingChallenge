import { Component, OnInit, Input } from '@angular/core';
import { Employee } from 'src/app/models/employee';

@Component({
  selector: 'app-employee-info',
  templateUrl: './employee-info.component.html',
  styleUrls: ['./employee-info.component.css']
})
export class EmployeeInfoComponent implements OnInit {

  @Input() employee: Employee;

  constructor() { }

  ngOnInit() {
  }

}
