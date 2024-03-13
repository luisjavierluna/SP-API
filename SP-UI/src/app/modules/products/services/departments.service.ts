import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map, of } from 'rxjs';
import { departmentDTO } from 'src/app/core/interfaces/departmentDTO';
import { response } from 'src/app/core/interfaces/response';
import { environment } from 'src/environments/environments';

@Injectable({
  providedIn: 'root'
})
export class DepartmentsService {

  constructor(private http: HttpClient) { }

  departments: departmentDTO[] = [
    {
      name: 'Humana',
      description: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Vitae voluptatem veritatis corrupti tempore autem officia animi maxime atque corporis odit porro omnis eaque facilis eius consequatur delectus magni, fugiat repellendus.'
    },
    {
      name: 'Humana',
      description: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Vitae voluptatem veritatis corrupti tempore autem officia animi maxime atque corporis odit porro omnis eaque facilis eius consequatur delectus magni, fugiat repellendus.'
    },
    {
      name: 'Humana',
      description: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Vitae voluptatem veritatis corrupti tempore autem officia animi maxime atque corporis odit porro omnis eaque facilis eius consequatur delectus magni, fugiat repellendus.'
    },
    {
      name: 'Humana',
      description: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Vitae voluptatem veritatis corrupti tempore autem officia animi maxime atque corporis odit porro omnis eaque facilis eius consequatur delectus magni, fugiat repellendus.'
    },
    {
      name: 'Humana',
      description: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Vitae voluptatem veritatis corrupti tempore autem officia animi maxime atque corporis odit porro omnis eaque facilis eius consequatur delectus magni, fugiat repellendus.'
    },
    {
      name: 'Humana',
      description: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Vitae voluptatem veritatis corrupti tempore autem officia animi maxime atque corporis odit porro omnis eaque facilis eius consequatur delectus magni, fugiat repellendus.'
    },
    {
      name: 'Humana',
      description: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Vitae voluptatem veritatis corrupti tempore autem officia animi maxime atque corporis odit porro omnis eaque facilis eius consequatur delectus magni, fugiat repellendus.'
    },
    {
      name: 'Humana',
      description: 'Lorem ipsum dolor sit amet consectetur adipisicing elit. Vitae voluptatem veritatis corrupti tempore autem officia animi maxime atque corporis odit porro omnis eaque facilis eius consequatur delectus magni, fugiat repellendus.'
    },
  ]

  private apiUrl = environment.apiURL + 'Departments'

  public getAll(pageNumber: number = 1, pageSize: number = 50):Observable<departmentDTO[]> {
    
    let params = new HttpParams();
    params = params.append('pageNumber', pageNumber.toString())
    params = params.append('pageSize', pageSize.toString())

    return this.http.get<response>(this.apiUrl, {params}).pipe(
      map(response => response.data)
    )
    
    // return of(this.departments)
  }
}
