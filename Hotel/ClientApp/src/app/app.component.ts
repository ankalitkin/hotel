import {Component} from '@angular/core';
import {Router} from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  oldToken: string;
  reload = true;

  constructor(private router: Router) {
  }

  check_auth() {
    this.update();
    return localStorage.getItem('token') != null;
  }

  onLogout() {
    localStorage.removeItem('token');
    this.router.navigate(['/user/login']);
    console.log("Token Удален");
    this.update();
  }

  update() {
    const token = localStorage.getItem('token');
    if (this.oldToken !== token) {
      this.oldToken = token;
      setTimeout(() => this.reload = false);
      setTimeout(() => this.reload = true);
    }
  }
}

