import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from 'src/app/components/home/home.component';
import { SharedModule } from '../shared/shared.module';
import { EmployeeEntryComponent } from 'src/app/components/employee-entry/employee-entry.component';
import { EmployeeInfoComponent } from 'src/app/components/employee-info/employee-info.component';
import { EmployeeEditComponent } from 'src/app/components/employee-edit/employee-edit.component';
import { FormsModule } from '@angular/forms';



@NgModule({
  declarations: [HomeComponent, EmployeeEntryComponent, EmployeeInfoComponent, EmployeeEditComponent],
  imports: [
    CommonModule,
    SharedModule,
    FormsModule
  ],
  exports: [
    HomeComponent,
    EmployeeEntryComponent,
    EmployeeInfoComponent,
    EmployeeEditComponent
  ],
  entryComponents: [
    EmployeeEditComponent
  ]
})
export class HomeModule { }
