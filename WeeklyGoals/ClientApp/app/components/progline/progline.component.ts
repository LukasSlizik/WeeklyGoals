import { Component, Input } from '@angular/core';
import { ProgressService } from "../../services/progress.service";
import { IProgress } from "../../models/IProgress";
import { HttpClient, HttpErrorResponse, HttpParams } from "@angular/common/http";

@Component({
    selector: '[progline]',
    providers: [ProgressService],
    templateUrl: './progline.component.html'
})

export class ProglineComponent {
    @Input('progline') progress: IProgress;
    private _updateProgressUrl: string = 'Home/UpdateProgress';

    constructor(private _httpClient: HttpClient) {
    }

    ngOnInit(): void {
    }

    public step($event: any): void {
        var target = $event.currentTarget;
        var id = target.attributes.id.nodeValue;
        switch (id) {
            case "up":
                this.progress.points += this.progress.stepSize;
                break;
            case "down":
                this.progress.points -= this.progress.stepSize;
                break;
            default:
                console.log("invalid value: " + id);
        }

        this._httpClient.get(this._updateProgressUrl, {
            params: new HttpParams()
                .append('progressId', this.progress.id.toString())
                .append('points', this.progress.points.toString())
        }).subscribe();
    }
}