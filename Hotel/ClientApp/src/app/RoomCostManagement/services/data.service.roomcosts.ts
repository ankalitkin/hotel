import { Injectable } from '@angular/core'
import { HttpClient } from '@angular/common/http';
import { RoomCost } from '../models/RoomCost';

@Injectable()

export class DataServiceRoomCosts {

  private url = "api/Admin/RoomCosts";

  constructor(private http: HttpClient) {
  }

  getProducts() {
    return this.http.get(this.url);
  }

  getProduct(id: number) {
    return this.http.get(this.url + '/' + id);
  }

  createProduct(product: RoomCost) {
    return this.http.post(this.url, product);
  }

  updateProduct(product: RoomCost) {
    return this.http.put(this.url + '/' + product.roomCostId, product);
  }

  deleteProduct(id: number) {
    return this.http.delete(this.url + '/' + id);
  }
}
