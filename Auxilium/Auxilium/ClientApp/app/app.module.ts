import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpModule } from '@angular/http';
import { HttpClientModule } from "@angular/common/http";

import { AppComponent } from './app.component';
import { Login } from "./login/login.component"
import { Match } from "./match/match.component";
import { DataService } from "./shared/dataService";

import { RouterModule } from "@angular/router";
import { FormsModule } from "@angular/forms";

let routes = [
    { path: "", component: AppComponent },
    { path: "match", component: Match },
    { path: "login", component: Login }
];

@NgModule({
    declarations: [
        AppComponent,
        Match,
        Login
    ],
    imports: [
        BrowserModule,
        HttpClientModule,
        HttpModule,
        RouterModule.forRoot(routes, {
            useHash: true,
            enableTracing: false //for Debugging of the Routes
        }),
        FormsModule
    ],
    providers: [
        DataService
    ],
    bootstrap: [AppComponent]
})

export class AppModule { }
