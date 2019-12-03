import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, BehaviorSubject } from 'rxjs';
import { Employee } from '../models/employee';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private $employees: BehaviorSubject<Employee[]>;

  constructor(private _httpClient: HttpClient) {
    this.$employees = new BehaviorSubject([]);
  }

  public createEmployee(employee: Employee): Observable<Employee> {
    return this._httpClient.post<Employee>(environment.apiBaseUrl + 'v1/Employee', employee);
  }

  public async getAllEmployees() {
    await this.refresh();
    return this.$employees;
  }

  private async refresh() {
    return await this._httpClient.get<Employee[]>(environment.apiBaseUrl + 'v1/Employee')
      .subscribe(x => this.$employees.next(x));
  }
}
