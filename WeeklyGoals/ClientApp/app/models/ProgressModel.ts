import { Serializable } from "./Serializable";

export class ProgressModel implements Serializable<ProgressModel> {
    public goalName: string;
    public description: string;
    public stepSize: number;
    public target: number;
    public unit: string;
    public progress: number;
    public points: number;

    constructor() {
    }

    deserialize(input: any): ProgressModel {
        this.goalName = input.goalName;
        this.description = input.description;
        this.stepSize = input.stepSize;
        this.target = input.target;
        this.unit = input.unit;
        this.progress = input.progress;
        this.points = input.points;

        return this;
    }
}