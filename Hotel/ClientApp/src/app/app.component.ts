import { Component } from '@angular/core';
import { PermitDirective } from './_auth/permit/permit.directive';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {

  constructor(private router: Router){}
  check_auth() {
    return localStorage.getItem('token') != null;
  }

  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
    console.log("Token Удален");
  }
}

