var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
import { Component } from '@angular/core';
import { DataService } from './data.service';
var RoomListComponent = /** @class */ (function () {
    function RoomListComponent(dataService) {
        this.dataService = dataService;
    }
    RoomListComponent.prototype.ngOnInit = function () {
        this.load();
    };
    RoomListComponent.prototype.load = function () {
        var _this = this;
        this.dataService.getProducts().subscribe(function (data) { return _this.rooms = data; });
    };
    RoomListComponent.prototype.delete = function (id) {
        var _this = this;
        this.dataService.deleteProduct(id).subscribe(function (data) { return _this.load(); });
    };
    RoomListComponent = __decorate([
        Component({
            templateUrl: './room-list.component.html'
        }),
        __metadata("design:paramtypes", [DataService])
    ], RoomListComponent);
    return RoomListComponent;
}());
export { RoomListComponent };
//# sourceMappingURL=room-list.component.js.map