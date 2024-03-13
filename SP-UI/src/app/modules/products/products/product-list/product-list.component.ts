import { Component, OnInit } from '@angular/core';
import { departmentDTO } from 'src/app/core/interfaces/departmentDTO';
import { DepartmentsService } from '../../services/departments.service';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {

  constructor(private departmentsService: DepartmentsService) {}
  departments: departmentDTO[] = []
  
  ngOnInit(): void {
    this.getAll()
  }

  getAll() {
    this.departmentsService.getAll()
    .subscribe({
      next: departments => this.departments = departments,
      error: error => console.log(error)
    })
  }
  
}
