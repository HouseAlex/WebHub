import { Component, OnDestroy } from '@angular/core';
import { Subscription } from 'rxjs';
import { HomeService } from './homes.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnDestroy {
    private subscription: Subscription = new Subscription();
    testData: string;

    constructor(
    private homeService: HomeService) {

        this.subscription.add(
            this.homeService.getTestData()
                .subscribe(result => {
                    this.testData = result;
                })
        )
    }

    ngOnDestroy(): void {
        this.subscription.unsubscribe();
    }
}
