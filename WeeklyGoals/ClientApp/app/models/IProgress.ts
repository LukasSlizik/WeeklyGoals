export interface IProgress {
    goalName: string;
    description: string;
    stepSize: number;
    target: number;
    unit: string;
    progress: number;
    points: number;
}