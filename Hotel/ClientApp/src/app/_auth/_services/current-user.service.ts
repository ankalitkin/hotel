import {Injectable} from '@angular/core';
import * as jwt_decode from 'jwt-decode';

@Injectable({
  providedIn: 'root'
})
export class CurrentUserService {

  constructor() {
  }

  getDecodedAccessToken(token: string): any {
    try{
      return jwt_decode(token);
    }
    catch(Error){
      console.error(Error);
      return null;
    }
  }

  getUserData(): object {
    let token = localStorage.getItem('token');
    if(!token)
      return undefined;
    return this.getDecodedAccessToken(token);
  }
}
