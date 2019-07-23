export class Room {
    constructor(
        public roomId?: number,
        public name?: string,
        public floor?: string,
        public roomTypeId?: number,
        public numberOfSeats?: number,
        public hasMiniBar?: boolean,
        public isFree?: boolean,
        public isDeleted ?: boolean) { }
}
