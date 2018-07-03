import { Component, Input } from '@angular/core';
import { ProgressService } from "../../services/progress.service";
import { IProgress } from "../../models/IProgress";

@Component({
    selector: '[progline]',
    providers: [ProgressService],
    templateUrl: './progline.component.html'
})

export class ProglineComponent {
    @Input('progline') progress: IProgress;

    constructor() {
    }

    ngOnInit(): void {
    }
}