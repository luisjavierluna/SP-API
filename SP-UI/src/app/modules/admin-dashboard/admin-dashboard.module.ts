import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';

import { DepartmentListComponent } from './pages/department-list/department-list.component';
import { DepartmentFormComponent } from './components/departments/department-form/department-form.component';
import { CreateDepartmentComponent } from './components/departments/create-department/create-department.component';



@NgModule({
  declarations: [
    DepartmentListComponent,
    DepartmentFormComponent,
    CreateDepartmentComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    ReactiveFormsModule
  ]
})
export class AdminDashboardModule { }
