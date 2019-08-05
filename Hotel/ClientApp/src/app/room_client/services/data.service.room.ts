import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable()
export class DataServiceRoom {
  private url = "api/Admin/RoomCosts";

  constructor(private http: HttpClient) {
  }

  getRooms() {
    return this.http.get(this.url);
  }

  getRoom(id: number) {
    return this.http.get(this.url + '/' + id);
  }
}
