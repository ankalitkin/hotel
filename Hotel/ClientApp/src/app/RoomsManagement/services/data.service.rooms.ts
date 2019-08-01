import { Injectable } from '@angular/core'
import { HttpClient } from '@angular/common/http';
import { Room } from '../../_models/room';

@Injectable()

export class DataServiceRooms {

    private url = "api/Rooms";

    constructor(private http: HttpClient) {
    }

    getProducts() {
        return this.http.get(this.url);
    }

    getProduct(id: number) {
        return this.http.get(this.url + '/' + id);
    }

    createProduct(product: Room) {
        return this.http.post(this.url, product);
    }

    updateProduct(product: Room) {
        return this.http.put(this.url + '/' + product.roomId, product);
    }

    deleteProduct(id: number) {
        return this.http.delete(this.url + '/' + id);
    }
}
