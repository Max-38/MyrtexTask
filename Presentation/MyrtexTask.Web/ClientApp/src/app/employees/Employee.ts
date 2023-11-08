import { DatePipe, DecimalPipe } from "@angular/common";

export class Employee {
  id?: string;
  department?: string;
  fullName?: string;
  dateOfBirth?: Date;
  dateOfEmployment?: Date;
  salary?: DecimalPipe;
}

