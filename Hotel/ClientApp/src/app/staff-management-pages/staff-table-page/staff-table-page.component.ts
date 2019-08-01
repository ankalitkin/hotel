import {Component, OnInit} from '@angular/core';
import {User} from '../../_models/user';
import {StaffService} from '../_services/staff.service';

@Component({
  selector: 'app-staff-table-page',
  templateUrl: './staff-table-page.component.html',
  styleUrls: ['./staff-table-page.component.scss']
})
export class StaffTablePageComponent implements OnInit {
  staff: User[];
  displayedColumns: string[] = [
    'userId',
    'lastName',
    'firstName',
    'birthDate',
    'phone',
    'email',
    // 'clientID',
    'roleName',
    'editButton'
    // 'isDeleted'
  ];

  constructor(private staffService: StaffService) {
  }

  ngOnInit() {
    this.staffService.getStaff().subscribe(value => this.staff = value);
  }

}
