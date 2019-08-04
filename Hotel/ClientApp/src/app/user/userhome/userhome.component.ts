
import { UserService } from 'src/app/user/services/user.service';
import { user_information } from '../models/user_information';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-userhome',
  templateUrl: './userhome.component.html',
  styleUrls: ['./userhome.component.scss']
})
export class UserhomeComponent implements OnInit {

  userDetails:user_information;
  constructor(private router: Router, private service: UserService) { }
  ngOnInit() {
    this.service.getUserProfile().subscribe(
      res => {
        this.userDetails = res;
      },
      err => {
        console.log(err);
      
      },
    );
  }
  
  onLogout() {
    localStorage.removeItem('token');
    
    this.router.navigate(['/user/login']);
  }

}
