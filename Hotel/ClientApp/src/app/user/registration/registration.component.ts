import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/user/services/user.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  constructor(public service: UserService, private router: Router, private toastr:ToastrService) { }

  ngOnInit() {
  }

  onSubmit() {
   // this.service.register().subscribe(data => this.router.navigateByUrl("/roommanager/rooms"));
   this.service.register().subscribe(
    (res: any) => {
        this.service.formModel.reset();
        this.toastr.success('Регистрация прошла успешно !'); 
    },
    err => {
      this.toastr.error('Что,то пошло не так :( ');
    }
  );
  };
}
