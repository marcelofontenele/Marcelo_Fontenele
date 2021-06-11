import { Component, OnInit } from '@angular/core';
import { Stock } from 'src/app/dto/stock';
import { InvestimentsService } from 'src/app/services/investiments.service';

@Component({
  selector: 'app-trends',
  templateUrl: './trends.component.html'
})
export class TrendsComponent implements OnInit {

    stocks: Stock[];

    constructor(private investimentsService: InvestimentsService) { }

    ngOnInit(): void {
        this.getTrends();
    }

    getTrends() {
        this.investimentsService.getTrends()
            .subscribe(_stocks => {
                this.stocks = _stocks;
            })
    }

}
