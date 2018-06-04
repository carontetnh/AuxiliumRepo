import { Component } from "@angular/core";
import { DataService } from "../shared/dataService";
import { Router } from "@angular/router";

@Component({
    selector: "the-login",
    templateUrl: "login.component.html"
})
export class Login {
    constructor(private data: DataService, private router: Router) { }

    errorMessage: string = "";
    public creds = {
        username: "",
        password: ""

    }

    onLogin() {
        this.data.login(this.creds)
            .subscribe(success => {
                if (success) {
                        this.router.navigate(["match"]);
                }
            }, err => this.errorMessage = "Failed to login")
    }
}