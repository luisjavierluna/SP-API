import { Component } from '@angular/core';
import { departmentDTO } from 'src/app/core/interfaces/departmentDTO';
import { DepartmentsService } from '../../../services/departments.service';

@Component({
  selector: 'app-create-department',
  templateUrl: './create-department.component.html',
  styles: [
  ]
})
export class CreateDepartmentComponent {

  constructor(private departmentService: DepartmentsService) {}

  successResponse!: boolean
  
  // Save Department
  create(department: departmentDTO){
    
    this.departmentService.create(department)
      .subscribe({
        next: response => {
          this.successResponse = response
          this.reloadPage()
        },
        error: error => console.log(error)
      })
  }

  // Refresh current page
  reloadPage(){
    setTimeout(() => {
      window.location.reload()
    }, 1500);
  }
}
