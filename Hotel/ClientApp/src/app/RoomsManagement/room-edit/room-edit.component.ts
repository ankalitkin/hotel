import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataServiceRooms } from '../services/data.service.rooms';
import { Room } from '../../_models/room';

@Component({
  templateUrl: './room-edit.component.html',
  providers: [DataServiceRooms]
})
export class RoomEditComponent implements OnInit {

    id: number;
    room: Room;    // изменяемый объект
    loaded: boolean = false;

    constructor(private dataService: DataServiceRooms, private router: Router, activeRoute: ActivatedRoute) {
        this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
    }

  ngOnInit() {
        if (this.id)
            this.dataService.getProduct(this.id)
                .subscribe((data: Room) => {
                    this.room = data;
                  if (this.room != null) this.loaded = true;
                });
    }

    save() {
      this.dataService.updateProduct(this.room).subscribe(data => this.router.navigateByUrl("/roommanager/rooms"));
    }
}
