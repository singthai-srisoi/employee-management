import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Employee } from 'src/app/models/employee.model';
import { EmployeesService } from 'src/app/services/employees.service';

@Component({
  selector: 'app-edit-employee',
  templateUrl: './edit-employee.component.html',
  styleUrls: ['./edit-employee.component.css']
})
export class EditEmployeeComponent implements OnInit {
  
    employeeDetails: Employee = {
      id: '00000000-0000-0000-0000-000000000000',
      name: '',
      email: '',
      phone: '',
      department: '',
      salary: 0
    };
    constructor(private route: ActivatedRoute, private employeeservice: EmployeesService,private router: Router) { }

    updateEmployee() {
      this.employeeservice.updateEmployee(this.employeeDetails.id, this.employeeDetails).subscribe({
        next: (employee) => {
          this.router.navigate(['/employees']);
        },
        error: (err) => {
          console.log(err);
        }
      });

    }

    deleteEmployee(id: string) {
      this.employeeservice.deleteEmployee(id).subscribe({
        next: (employee) => {
          this.router.navigate(['/employees']);
        },
        error: (err) => {
          console.log(err);
        }
      });
    }
  
    ngOnInit(): void {
      this.route.paramMap.subscribe({
        next: params => {
          const id = params.get('id');

          if (id) {
            //call api to get employee by id
            this.employeeservice.getEmployee(id).subscribe({
              next: resp => {
                this.employeeDetails = resp;
              }
            })
          }
        }
      });
    }
}