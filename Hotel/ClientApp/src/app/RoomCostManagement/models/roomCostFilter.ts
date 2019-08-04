import { Range } from './range';

export class RoomCostFilter {
  constructor(
    public cost?: Range,
    public numberOfSeats?: Range,
    public idCategory?: number,
    public hasMiniBar?: number
  ) { }
}
