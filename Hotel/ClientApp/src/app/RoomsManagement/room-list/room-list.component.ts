import { Component, OnInit } from '@angular/core';
import { DataServiceRooms } from '../services/data.service.rooms';
import { Room } from '../models/Room';
import { RoomFilter } from '../models/RoomFilter';
import { fadeIn } from 'igniteui-angular';

//<блок данных для фильтра>
enum SortedBy { FloorAndNumber, Seats }

@Component({
  templateUrl: './room-list.component.html',
  providers: [DataServiceRooms],
  styleUrls: ['./room-list.component.scss']
})

export class RoomListComponent implements OnInit {
  //<-- блок данных для фильтра>
  allRooms: Room[];
  sortedBy: SortedBy = SortedBy.FloorAndNumber;
  order: number = 1;
  isFilter: boolean = false;
  roomFilter: RoomFilter = new RoomFilter(
    "", 1, 0, false, false
  )
  //</блок данных для фильтра -->

  rooms: Room[];
  isLoaded: Boolean = false;
  masCategoryName: string[] = ["Эконом", "Обычный", "Люкс"];

    constructor(private dataService: DataServiceRooms) { }

    ngOnInit() {
        this.load();
    }

  load() {
    this.dataService.getProducts().subscribe((data: Room[]) => {
      this.allRooms = data;
      this.isLoaded = true;
      this.filter();
      this.sortByOption();
    });
    }

  delete(roomId: number) {
      this.dataService.deleteProduct(roomId).subscribe(data => this.load());
  }

  boolToRus(boolvar: boolean) {
    return boolvar ? "Присутсвует" : "Отсутствует";
  }

  nameOfCategory(idCategory: number) {
    return this.masCategoryName[idCategory - 1];
  }


  //<-- блок данных для фильтра>
  filter() {
    this.rooms = this.allRooms.filter(item =>
      (!this.roomFilter.floor ||
        item.floor == this.roomFilter.floor) &&
      (!this.roomFilter.numberOfSeats ||
        item.numberOfSeats >= this.roomFilter.numberOfSeats) &&
      (this.roomFilter.idCategory == 0||
        item.roomTypeId == this.roomFilter.idCategory) &&
      (!this.roomFilter.hasMiniBar ||
        item.hasMiniBar) &&
      (!this.roomFilter.onlyFree || item.isFree));   
  }

  // Сортировка, c использованием функции f
  sort(f: any) {
    this.rooms = this.rooms.sort(f);
  }

  // Смена направления сортировки
  changeOrder() {
    this.order *= -1;
  }

  // Сравнение строк result = -1 | 0  | 1
  stringComparison(str1, str2) {
    if (str1 > str2)
      return 1;
    if (str1 < str2)
      return -1;
    return 0;
  }

  // Сортиовка по этажу и номеру комнаты
  sortedByFloorAndNumber(r1, r2) {
    if (r1.floor != r2.floor)
      return (this.stringComparison(r1.floor, r2.floor) * this.order);

    return (this.stringComparison(r1.name, r2.name) * this.order);
  }

  // Сортировка по определенному критерию
  sortByOption() {
    switch (this.sortedBy) {
      case SortedBy.FloorAndNumber: this.sort((r1, r2) => {
        if (r1.floor != r2.floor)
          return (this.stringComparison(r1.floor, r2.floor) * this.order);

        return (this.stringComparison(r1.name, r2.name) * this.order);
      }
        );
        break;
      case SortedBy.Seats: this.sort((r1, r2) => (r1.numberOfSeats - r2.numberOfSeats) * this.order);
        break;
    }
  }

  // Событие при нажаттии на кнопку "Поиск"
  public onSearchClick() {
    this.filter();
    this.sortByOption();
  }

  criterion: number = 0;

  public onCriterionClick() {
    this.sortedBy = SortedBy[SortedBy[this.criterion]];
    this.onSearchClick();
  }

  onFilter() {
    this.isFilter = !this.isFilter;
    if (!this.isFilter) {
      this.roomFilter.floor = '';
      this.roomFilter.hasMiniBar = false;
      this.roomFilter.idCategory = 0;
      this.roomFilter.numberOfSeats = 1;
      this.roomFilter.onlyFree = false;
      this.onSearchClick();
    }
  }

  filterName() {
    return this.isFilter ? "Спрятать фильтр" : "Показать фильтр";
  }
   //</блок данных для фильтра -->

}
