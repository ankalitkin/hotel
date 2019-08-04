import { jsonIgnoreReplacer, jsonIgnore } from 'json-ignore';

export class Room {

  @jsonIgnore() public TheNoumber: number; // для нумерации списка комнат(так проще вроде бы)
  @jsonIgnore() public Cost: number;

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
