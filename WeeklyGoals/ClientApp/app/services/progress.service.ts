import { Injectable } from '@angular/core';
import { ProgressModel } from "../models/ProgressModel";

@Injectable()
export class ProgressService {
    constructor() { }

    getProgress() {
        return new ProgressModel();
    }
}