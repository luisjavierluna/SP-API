import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';

import { DepartmentListComponent } from './departments/department-list/department-list.component';



@NgModule({
  declarations: [
    DepartmentListComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule
  ]
})
export class ProductsModule { }
