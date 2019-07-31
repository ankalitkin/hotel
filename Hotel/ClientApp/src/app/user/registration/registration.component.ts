import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/_shared/user.service';
import { Router } from '@angular/router';
//import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  constructor(public service: UserService, private router: Router) { }

  ngOnInit() {
  }

  onSubmit() {
    this.service.register().subscribe(data => this.router.navigateByUrl("/roommanager/rooms"));
  };
}
