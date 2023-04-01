import { NgModule } from '@angular/core';
import { AppComponent } from '../app.component';
import { HomeComponent } from './home.component';
import { HomeService } from './homes.service';

@NgModule({
    declarations: [
        HomeComponent
    ],
    imports: [
    ],
    providers: [
        HomeService
    ]
})
export class HomeModule { }

