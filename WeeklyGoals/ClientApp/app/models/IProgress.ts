export interface IProgress {
    id: number;
    goalName: string;
    description: string;
    stepSize: number;
    target: number;
    factor: number;
    unit: string;
    progress: number;
    points: number;
    actualPoints: number;
}