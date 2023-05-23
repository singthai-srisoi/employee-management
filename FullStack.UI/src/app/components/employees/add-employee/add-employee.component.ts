import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Employee } from 'src/app/models/employee.model';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-add-employee',
  templateUrl: './add-employee.component.html',
  styleUrls: ['./add-employee.component.css']
})
export class AddEmployeeComponent {
  addEmployeeRequest: Employee = {
    id: '00000000-0000-0000-0000-000000000000',
    name: '',
    email: '',
    phone: '',
    department: '',
    salary: 0
  };

  constructor(private emplyeeService: EmployeesService,private router: Router) { }

  addEmployee() {
    return this.emplyeeService.addEmployee(this.addEmployeeRequest)
    .subscribe({
      next: (employee) => {
        this.router.navigate(['/employees']);
      },
      error: (err) => {
        console.log(err);
      }
    })
  }
}
