import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { ReactiveFormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';

import { DepartmentListComponent } from './departments/department-list/department-list.component';
import { DepartmentFormComponent } from './departments/department-form/department-form.component';
import { CreateDepartmentComponent } from './departments/create-department/create-department.component';



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
export class ProductsModule { }
