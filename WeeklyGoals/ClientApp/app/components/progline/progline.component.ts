import { Component } from '@angular/core';
import { ProgressModel } from "../../models/ProgressModel";
import { ProgressService } from "../../services/progress.service";

@Component({
    selector: 'progline',
    providers: [ProgressService],
    templateUrl: './progline.component.html'
})

export class ProglineComponent {
    public progressModel: ProgressModel;

    constructor(private _progressService: ProgressService) {
        console.log('constructor');
    }

    ngOnInit(): void {
        console.log('progline component OnInit');
        this.progressModel = this._progressService.getProgress();
    }
}