import { Inject, Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DecimalPipe } from '@angular/common';
import { Employee } from './Employee';
import { Observable, map } from 'rxjs';

@Injectable()
export class EmployeeService {

  private url: string;
  constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.url = baseUrl + 'employees';
  }

  //Обращение к WebApi для получения списка сотрудников
  getEmployees() : Observable<Employee[]> {
    return this.http.get<Employee[]>(this.url).pipe();
  }

  //Обращение к WebApi для добавления нового сотрудника в базу данных
  createEmployee(employee: Employee): Observable<Employee> {
    return this.http.post<Employee>(this.url, employee).pipe();
  }

  //Обращение к WebApi для обновления данных о сотруднике
  updateEmployee(employee: Employee) : Observable<Employee> {
    return this.http.put<Employee>(this.url, employee).pipe(map(() => employee));
  }

  //Обращение к WebApi для удаления сотрудника по его Id
  deleteEmployee(id?: string): Observable<{}> {
    return this.http.delete(this.url + "/" + id).pipe();
  }
}
