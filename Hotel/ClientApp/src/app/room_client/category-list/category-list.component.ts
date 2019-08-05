import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataServiceRoom } from '../services/data.service.room';
import { RoomCost } from '../../RoomCostManagement/models/RoomCost';
import { SliderType } from "igniteui-angular";
import { RoomCostFilter } from '../../RoomCostManagement/models/roomCostFilter';
import { Range } from '../../RoomCostManagement/models/range';

enum SortedBy { Cost }

@Component({
  selector: 'app-category-list',
  templateUrl: './category-list.component.html',
  styleUrls: ['./category-list.component.scss'],
  providers: [DataServiceRoom]
})
export class CategoryListComponent implements OnInit {

  allRoomCosts: RoomCost[]; // Все данные, загруженные с сервера
  roomCosts: RoomCost[];    // Отфильтрованные данные (фильтр)
  masCategoryName: string[] // Массив названий типов комнат
    = ["Эконом", "Обычный", "Люкс"];

  isLoaded: Boolean = false;// Загружены ли все данные
  sortedBy: SortedBy = SortedBy.Cost;//Критерий сортировки (фильтр)

  order: number = 1;// Порядок сортировки (фильтр)
  isFilter: boolean = false;// Для отображения/скрытия фильтра (фильтр)
  // значения минимальной и максимальносй стоимости (фильтр)
  mincost: number = -1;
  maxcost: number = -1;
  public sliderType = SliderType;
  // Данные для фильтра (фильтр)
  public roomCostFilter: RoomCostFilter = new RoomCostFilter(
    new Range(0, 999999999),
    new Range(1, 5),
    0, 0);
  constructor(private dataService: DataServiceRoom) { }

  imagesPull: string[] = ["https://cache.marriott.com/marriottassets/marriott/EVNMC/evnmc-guestroom-0107-hor-clsc.jpg?interpolation=progressive-bilinear&downsize=378px:*",
    "https://marriott-sochi-hotel.ru/public/sites/pages/57/45171.jpg",
    "https://marriott-sochi-hotel.ru/public/sites/pages/57/4789.jpg",
    "https://marriott-sochi-hotel.ru/public/sites/pages/57/32331.jpg",
    "https://marriott-sochi-hotel.ru/public/sites/pages/57/45177.jpg"];

  ngOnInit() {
    this.load();
  }

  // Обработка слайдеров выбора диапазона цены (фильтр)
  public updatePriceRange(event) {
    const prevPriceRange = this.roomCostFilter.cost;
    switch (event.id) {
      case "lowerInput": {
        if (!isNaN(parseInt(event.value, 10))) {
          this.roomCostFilter.cost = new Range(event.value, prevPriceRange.upper);
        }
        break;
      }
      case "upperInput": {
        if (!isNaN(parseInt(event.value, 10))) {
          this.roomCostFilter.cost = new Range(prevPriceRange.lower, event.value);
        }
        break;
      }
    }
  }

  // При нажати на кнопку "поиск" (фильтр)
  public onSearchClick() {
    this.filter();
    this.sortByOption();
  }

  // Проверка на принадлежность диапазону (фильтр)
  isInRange(num: number, range: Range) {
    return (num >= range.lower && num <= range.upper);
  }

  // Сортировка, использующая переданную функцию (фильтр)
  sort(f: any) {
    this.roomCosts = this.roomCosts.sort(f);
  }

  // Смена порядка сортировки (фильтр)
  changeOrder() {
    this.order *= -1;
  }

  // Сортировка по критерию (фильтр)
  sortByOption() {
    switch (this.sortedBy) {
      case SortedBy.Cost: this.sort((rc1, rc2) => (rc1.cost - rc2.cost) * this.order);
        break;
    }
  }

  // (фильтр)
  filter() {
    this.roomCosts = this.allRoomCosts.filter(item =>
      this.isInRange(item.cost, this.roomCostFilter.cost) &&
      (this.roomCostFilter.numberOfSeats.lower == 0 ||
        item.numberOfSeats >= this.roomCostFilter.numberOfSeats.lower) &&
      (this.roomCostFilter.hasMiniBar == 0 ||
        ((this.roomCostFilter.hasMiniBar == 1) == item.hasMiniBar)) &&
      (this.roomCostFilter.idCategory == 0 ||
        this.roomCostFilter.idCategory == item.categoryId));
  }

  public load() {
    this.isLoaded = false;
    this.dataService.getRooms().subscribe((data: RoomCost[]) => {
      this.allRoomCosts = data;//(фильтр)
      this.mincost = this.maxcost = -1;//(фильтр)
      this.isLoaded = true;
      this.filter();//(фильтр)
      this.sortByOption();//(фильтр)
    });

  }

  boolToRus(boolvar: boolean) {
    return boolvar ? "Есть" : "Нет";
  }

  nameOfCategory(idCategory: number) {
    return this.masCategoryName[idCategory - 1];
  }

  // минимальная стоимость (вычисляется один раз) (фильтр)
  public minCost() {
    if (this.mincost == -1 && this.allRoomCosts.length > 0) {
      let res: number = this.allRoomCosts[0].cost;
      for (let i: number = 1; i < this.allRoomCosts.length; ++i)
        if (res > this.allRoomCosts[i].cost)
          res = this.allRoomCosts[i].cost;
      this.mincost = res;
      return res;
    }
    return this.mincost;
  }

  // максимальная стоимость
  public maxCost() {
    if (this.maxcost == -1 && this.allRoomCosts.length > 0) {
      let res: number = this.allRoomCosts[0].cost;
      for (let i: number = 1; i < this.allRoomCosts.length; ++i)
        if (res < this.allRoomCosts[i].cost)
          res = this.allRoomCosts[i].cost;
      this.maxcost = res;
      return res;
    }
    return this.maxcost;
  }

  onFilter() {
    this.isFilter = !this.isFilter;
    if (!this.isFilter) {
      this.roomCostFilter.cost.lower = this.minCost();
      this.roomCostFilter.cost.upper = this.maxCost();
      this.roomCostFilter.hasMiniBar = 0;
      this.roomCostFilter.idCategory = 0;
      this.roomCostFilter.numberOfSeats.lower = 0;
    }
  }

  filterName() {
    return this.isFilter ? "Спрятать фильтр" : "Показать фильтр";
  }

  oldToken: string;
  reload = true;

  check_auth() {
    const token = localStorage.getItem('token');
    if (this.oldToken !== token) {
      this.oldToken = token;
      setTimeout(() => this.reload = false);
      setTimeout(() => this.reload = true);
    }
    return localStorage.getItem('token') != null;
  }
}
