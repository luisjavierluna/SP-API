import { Component, OnInit } from '@angular/core';
import { departmentDTO } from 'src/app/core/interfaces/departmentDTO';
import { paginationDTO } from 'src/app/core/interfaces/paginationDTO';
import { DepartmentsService } from '../../services/departments.service';

@Component({
  selector: 'app-department-list',
  templateUrl: './department-list.component.html',
  styleUrls: ['./department-list.component.scss']
})
export class DepartmentListComponent implements OnInit {

  constructor(private departmentsService: DepartmentsService) {}
  
  departments: departmentDTO[] = []

  pagination: paginationDTO = {
    pageNumber: 1,
    pageSize: 10,
    totalNumberRecords: 100,
    totalNumberPages: 10,
    isFirstPage: true,
    isLastPage: false
  }

  totalNumberRecords!: number
  
  ngOnInit(): void {
    this.getAmount()
  }

  // Get all but paginated
  getPaginated() {
    this.departmentsService.getPaginated(this.pagination.pageNumber, this.pagination.pageSize)
    .subscribe({
      next: departments => {this.departments = departments},
      error: error => console.log(error)
    })
  }

  // Get total amount of records in the DB
  getAmount() {
    this.departmentsService.getAmount().subscribe({
      next: result => {
        this.totalNumberRecords = result
        this.fillPagination()
        this.getPaginated()
      },
      error: error => console.log(error)
    })
  }

  // Select Page
  selectPage(pageNumber: number) {
    this.fillPagination(pageNumber, this.pagination.pageSize)
    this.getPaginated()
  }

  // Change number of records per page
  changePageSize(event: any) {
    let pageSize: number = event.target.value

    this.fillPagination(1, pageSize)
    this.getPaginated()
  }
  
  // Fill pagination
  fillPagination(pageNumber = 1, pageSize = 10) {

    this.pagination = {
      pageNumber: pageNumber,
      pageSize: pageSize,
      totalNumberRecords: this.totalNumberRecords,
      totalNumberPages: Math.ceil(this.totalNumberRecords / pageSize),
      isFirstPage: pageNumber == 1,
      isLastPage: pageNumber == this.pagination.totalNumberPages
    }

  }

}
