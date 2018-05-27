import { Component } from '@angular/core';
import { ProgressService } from "../../services/progress.service";
import { ProgressModel } from "../../models/ProgressModel";
import { SimpleModel } from "../../models/SimpleModel";
import { Http } from "@angular/http";

@Component({
    selector: 'progtable',
    templateUrl: './progtable.component.html'
})

export class ProgtableComponent {
    private _progress: Array<ProgressModel> = new Array<ProgressModel>();

    constructor(private _http: Http) {
    }

    onClickMe(): void {
        let params: URLSearchParams = new URLSearchParams();
        params.set('weekid', '1');

        this._http.get('Home/GetProgressForWeek', { search: 'weekId=1' })
            .subscribe((data: any) => {
                var json = JSON.parse(data._body);
                for (var obj of json) {
                    var model = new ProgressModel();
                    model.description = obj['description'];
                    this._progress.push(model);
                }
            }
        );
    }

    ngOnInit(): void {
    }
}