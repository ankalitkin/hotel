import { Component, OnInit } from '@angular/core';
import { DataServiceRooms } from '../services/data.service.rooms';
import { Room } from '../models/Room';

@Component({
  templateUrl: './room-list.component.html',
  providers: [DataServiceRooms]
})

export class RoomListComponent implements OnInit {

    rooms: Room[];
    constructor(private dataService: DataServiceRooms) { }

    ngOnInit() {
        this.load();
    }

    load() {
        this.dataService.getProducts().subscribe((data: Room[]) => this.rooms = data);
    }

    delete(id: number) {
        this.dataService.deleteProduct(id).subscribe(data => this.load());
    }
}
