import { Component, OnInit } from "@angular/core";
import { SliderType } from "igniteui-angular";

@Component({
  selector: "double-slider",
  styleUrls: ["./slider-component.scss"],
  templateUrl: "./slider-component.html"
})
export class DoubleSliderComponent implements OnInit {
  public sliderType = SliderType;
  public priceRange: PriceRange = new PriceRange(200, 800);

  constructor() { }

  public updatePriceRange(event) {
    const prevPriceRange = this.priceRange;
    switch (event.id) {
      case "lowerInput": {
        if (!isNaN(parseInt(event.value, 10))) {
          this.priceRange = new PriceRange(event.value, prevPriceRange.upper);
        }
        break;
      }
      case "upperInput": {
        if (!isNaN(parseInt(event.value, 10))) {
          this.priceRange = new PriceRange(prevPriceRange.lower, event.value);
        }
        break;
      }
    }
  }

  public ngOnInit() {
  }
}

class PriceRange {
  constructor(
    public lower: number,
    public upper: number
  ) {
  }
}
