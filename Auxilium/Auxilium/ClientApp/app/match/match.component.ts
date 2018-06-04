import { Component } from "@angular/core";
import { DataService } from "../shared/dataService";
import { Router } from "@angular/router";
@Component({
    selector: "match",
    templateUrl: "match.component.html",
    styleUrls: []
})
export class Match {
    constructor(private data: DataService, private router: Router) { }
}