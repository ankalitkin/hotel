import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { UserService } from 'src/app/user/services/user.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  formModel =
    {
      Email: "",
      Password: ""
    }
  constructor(private service: UserService, private router: Router, private toastr: ToastrService) { }
  ngOnInit() {
   // if (localStorage.getItem('token') != null)
    // this.router.navigateByUrl('');
  }

  onSubmit(form: NgForm) {

    this.service.login(form.value).subscribe(
      (res: any) => {
        console.log(res.token)
        localStorage.setItem('token', res.token);
        this.router.navigateByUrl('');
      },
      err => {
          this.toastr.error('Что то пошло не так ');
      }
    );
  }
}
