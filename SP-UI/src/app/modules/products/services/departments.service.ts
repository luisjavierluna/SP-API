import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map, of, skip, take } from 'rxjs';
import { departmentDTO } from 'src/app/core/interfaces/departmentDTO';
import { response } from 'src/app/core/interfaces/response';
import { environment } from 'src/environments/environments';

@Injectable({
  providedIn: 'root'
})
export class DepartmentsService {

  constructor(private http: HttpClient) { }

  private apiUrl = environment.apiURL + 'Departments'

  public getAmount():Observable<number>{
    return this.http.get<response>(`${this.apiUrl}/amount`).pipe(
      map(response => response.data)
    )
  }

  public getPaginated(pageNumber: number, pageSize: number):Observable<departmentDTO[]> {
    
    let params = new HttpParams();
    params = params.append('pageNumber', pageNumber.toString())
    params = params.append('pageSize', pageSize.toString())

    return this.http.get<response>(this.apiUrl, {params}).pipe(
      map(response => response.data)
    )
  }

  public create(department: departmentDTO):Observable<boolean> {
    return this.http.post<response>(this.apiUrl, department).pipe(
      map(response => response.succeeded)
    )
  }
}
