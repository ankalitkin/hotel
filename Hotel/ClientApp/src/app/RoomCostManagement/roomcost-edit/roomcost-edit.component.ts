import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataServiceRoomCosts } from '../services/data.service.roomcosts';
import { RoomCost } from '../models/RoomCost';

@Component({
  templateUrl: './roomcost-edit.component.html',
  providers: [DataServiceRoomCosts],
  styleUrls: ['./roomcost-edit.component.scss']
})
export class RoomCostEditComponent implements OnInit {

  id: number;
  roomCost: RoomCost;    // изменяемый объект
  loaded: boolean = false;

  constructor(private dataService: DataServiceRoomCosts, private router: Router, activeRoute: ActivatedRoute) {
    this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
  }

  ngOnInit() {
    if (this.id)
      this.dataService.getProduct(this.id)
        .subscribe((data: RoomCost) => {
          this.roomCost = data;
          if (this.roomCost != null) this.loaded = true;
        });
  }

  save() {
    this.dataService.updateProduct(this.roomCost)
      .subscribe(data => this.router.navigateByUrl("/roomcostmanager/roomCosts"));
  }
}
