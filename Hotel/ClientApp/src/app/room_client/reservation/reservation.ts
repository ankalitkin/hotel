import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute, Data } from '@angular/router';
import { DataServiceRoom } from '../services/data.service.room';
import { RoomCost } from '../../RoomCostManagement/models/RoomCost'
@Component({
  templateUrl: './reservation.html',
  providers: [DataServiceRoom],
  styleUrls: ['./reservation.scss']
})

export class ReservationComponent implements OnInit {

  id: number;
  roomCost: RoomCost;    // изменяемый объект
  loaded: boolean = false;
  masCategoryName: string[] // Массив названий типов комнат
    = ["Эконом", "Обычный", "Люкс"];
  start: Data;
  end: Data;

  imagesPull: string[] = ["https://cache.marriott.com/marriottassets/marriott/EVNMC/evnmc-guestroom-0107-hor-clsc.jpg?interpolation=progressive-bilinear&downsize=720px:*",
    "https://marriott-sochi-hotel.ru/public/sites/pages/57/45171.jpg",
    "https://marriott-sochi-hotel.ru/public/sites/pages/57/4789.jpg",
    "https://marriott-sochi-hotel.ru/public/sites/pages/57/32331.jpg",
    "https://marriott-sochi-hotel.ru/public/sites/pages/57/45177.jpg"];

  constructor(private dataService: DataServiceRoom, private router: Router, activeRoute: ActivatedRoute) {
    this.id = Number.parseInt(activeRoute.snapshot.params["id"]);
  }

  ngOnInit() {
    if (this.id)
      this.dataService.getRoom(this.id)
        .subscribe((data: RoomCost) => {
          this.roomCost = data;
          if (this.roomCost != null) this.loaded = true;
        });
  }

  boolToRus(boolvar: boolean) {
    return boolvar ? "Есть" : "Нет";
  }

  nameOfCategory(idCategory: number) {
    return this.masCategoryName[idCategory - 1];
  }

 // найти

 // забронировать
}
