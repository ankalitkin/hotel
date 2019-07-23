import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { DataServiceRooms } from '../services/data.service.rooms';
import { Room } from '../models/Room';

@Component({
  templateUrl: './room-create.component.html',
  providers: [DataServiceRooms]
})

export class RoomCreateComponent {

    room: Room = new Room();    // добавляемый объект
    constructor(private dataService: DataServiceRooms, private router: Router) { }
    save() {
        this.dataService.createProduct(this.room).subscribe(data => this.router.navigateByUrl("/"));
    }
}
