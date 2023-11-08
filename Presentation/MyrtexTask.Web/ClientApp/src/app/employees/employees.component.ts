import { Component, OnInit, ViewChild } from '@angular/core';
import { EmployeeService } from './employee.service';
import { Employee } from './Employee';
import { AgGridAngular } from 'ag-grid-angular';


@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  providers: [EmployeeService]
})
export class EmployeesComponent implements OnInit {

  employee: Employee = new Employee();

  //Параметризация столбцов
  columnDefs: any[] = [

    { headerName: 'Id', field: "id", sortable: "true", filter: "true", hide: "true" },

    { headerName: 'Отдел', field: "department", sortable: "true", filter: "true" },

    { headerName: 'Полное имя', field: "fullName", sortable: "true", filter: "true" },


    {
      headerName: 'Дата рождения', field: "dateOfBirth", sortable: "true", filter: "agDateColumnFilter", cellRenderer: (data: { value: string | number | Date; }) => {
        return data.value ? (new Date(data.value)).toLocaleDateString() : '';
      }, cellDataType: 'date',

      //компаратор для фильтрации даты рождения
      filterParams: {
        comparator: (filterLocalDateAtMidnight: any, cellValue: any) => {
          const dateAsString = cellValue;

          if (dateAsString == null) {
            return 0;
          }

          const dateParts = dateAsString.split('-');
          const year = Number(dateParts[0]);
          const month = Number(dateParts[1]) - 1;
          const day = Number(dateParts[2].slice(0, 2));
          const cellDate = new Date(year, month, day);

          if (cellDate < filterLocalDateAtMidnight) {
            return -1;
          } else if (cellDate > filterLocalDateAtMidnight) {
            return 1;
          }
          return 0;
        }
      }
    },


    {
      headerName: 'Дата приема на работу', field: "dateOfEmployment", sortable: "true", filter: "agDateColumnFilter", cellRenderer: (data: { value: string | number | Date; }) => {
        return data.value ? (new Date(data.value)).toLocaleDateString() : '';
      }, cellDataType: 'date',

      //компаратор для фильтрации даты приема на работу
      filterParams: {
        comparator: (filterLocalDateAtMidnight: any, cellValue: any) => {
          const dateAsString = cellValue;

          if (dateAsString == null) {
            return 0;
          }

          const dateParts = dateAsString.split('-');
          const year = Number(dateParts[0]);
          const month = Number(dateParts[1]) - 1;
          const day = Number(dateParts[2].slice(0, 2));
          const cellDate = new Date(year, month, day);

          if (cellDate < filterLocalDateAtMidnight) {
            return -1;
          } else if (cellDate > filterLocalDateAtMidnight) {
            return 1;
          }
          return 0;
        }
      }
    },


    { headerName: 'Зарплата', field: "salary", sortable: "true", filter: "true" }
  ];
  rowData: Employee[] = [];

  @ViewChild(AgGridAngular) agGrid!: AgGridAngular;

  constructor(private employeeService: EmployeeService) { }

  ngOnInit(): void {
    this.loadEmployees();
  }

  //Загрузка данных таблицы
  loadEmployees() {
    this.employeeService.getEmployees()
      .subscribe(data => {
        this.rowData = data;
      });
  }

//Добавление и редактирование записи
  save() {
    if (this.employee.id == null) {
      this.employeeService.createEmployee(this.employee)
        .subscribe(data => this.loadEmployees());
    } else {
      this.employeeService.updateEmployee(this.employee)
        .subscribe(data => this.loadEmployees());

    }
    this.clearSelection();
  }

  //Удаление записи
  delete(p: Employee) {
    this.employeeService.deleteEmployee(p.id)
      .subscribe(data => this.loadEmployees());

    this.clearSelection();
  }

  //Очистка выбора строки при добавлении записи
  add() {
    this.clearSelection();
  }

  //Выбор строки
  onSelection() {
    if (this.agGrid.api.getSelectedRows().length == 1)
      this.employee = this.agGrid.api.getSelectedRows()[0];
  }

  //Очистить выбор строки
  clearSelection() {
    this.agGrid.api.deselectAll();
    this.employee = new Employee();
  }
}
