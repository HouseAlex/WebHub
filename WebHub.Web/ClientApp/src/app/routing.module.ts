import { NgModule } from '@angular/core';
import { RouterModule, Routes } from "@angular/router";
import { HomeComponent } from './home/home.component';

const appRoutes: Routes = [
    {
        path: '',
        //redirectTo: '',
        component: HomeComponent,
        pathMatch : 'full'
    }
]

@NgModule({
    imports: [
        RouterModule.forRoot(appRoutes)
    ],
    exports: [RouterModule],
    providers: []
})
export class RoutingModule { }
