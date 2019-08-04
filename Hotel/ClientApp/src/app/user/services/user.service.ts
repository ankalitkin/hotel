import {Injectable} from '@angular/core';
import {FormBuilder, FormGroup, Validators} from '@angular/forms';
import {HttpClient} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  readonly BaseUrl = "api/user";
  formModel = this.fb.group({
    UserName: ['', Validators.required],
    Email: ['', Validators.email],
    FullName: ['',],
    Phone: ['', Validators.required],
    Passwords: this.fb.group({
      Password: ['', [Validators.required, Validators.minLength(4)]],
      ConfirmPassword: ['', Validators.required]
    }, {validator: this.comparePasswords})

  });

  constructor(private fb: FormBuilder, private http: HttpClient) {
  }

  comparePasswords(fb: FormGroup) {
    let confirmPswrdCtrl = fb.get('ConfirmPassword');

    if (confirmPswrdCtrl.errors == null || 'passwordMismatch' in confirmPswrdCtrl.errors) {
      if (fb.get('Password').value != confirmPswrdCtrl.value)
        confirmPswrdCtrl.setErrors({passwordMismatch: true});
      else
        confirmPswrdCtrl.setErrors(null);
    }
  }

  register() {
    var body =
      {
        firstname: this.formModel.value.UserName,
        lastname: this.formModel.value.FullName,
        password: this.formModel.value.Passwords.Password,
        email: this.formModel.value.Email

      };

    console.log(this.formModel.value.UserName);
    return this.http.post(this.BaseUrl + "/Registration", body);
  }

  login(formData) {
    return this.http.post(this.BaseUrl + "/Login", formData);
  }

  getUserProfile() {
    let token = localStorage.getItem('token');

    return this.http.get(this.BaseUrl + '/userprofile');
  }
}
