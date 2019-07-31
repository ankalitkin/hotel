import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from 'src/app/_shared/user.service';
import { Router } from '@angular/router';
//import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  formModel=
  {
    Email:"",
    Password:""
  }
  constructor(private service: UserService, private router: Router) { }
  ngOnInit() {
    //if (localStorage.getItem('token') != null)
    //  this.router.navigateByUrl('/roommanager/rooms');
  }

  onSubmit(form: NgForm) {
    this.service.login(form.value).subscribe(
      (res: any) => {
        console.log(res.token);
       localStorage.setItem('token', res.token);
        this.router.navigateByUrl('/roommanager/rooms');
      },
      err => {
        console.log("Всё плохо");
        this.router.navigateByUrl('/user/registration');
      }
    );
  }
}
