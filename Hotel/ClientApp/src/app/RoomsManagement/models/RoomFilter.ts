export class RoomFilter {
  constructor(
    public floor?: string,
    public numberOfSeats?: number,
    public idCategory?: number,
    public hasMiniBar?: boolean,
    public onlyFree?: boolean
  ) { }
}
