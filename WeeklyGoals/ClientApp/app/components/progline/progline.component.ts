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


    constructor(private _httpClient: HttpClient, private _progressSvc: ProgressService) {
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

        this._progressSvc.updateProgress(this.progress.id, this.progress.points);
    }
}