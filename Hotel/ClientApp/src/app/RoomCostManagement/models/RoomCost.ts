export class RoomCost {
  constructor(
    public roomCostId?: number,
    public categoryId?: number,
    public numberOfSeats?: number,
    public hasMiniBar?: boolean,
    public cost?: number
  ) { }
}
