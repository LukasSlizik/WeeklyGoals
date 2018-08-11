export class Goal {

    constructor(
        public name: string,
        public description: string,
        public stepSize: number,
        public unit: string,
        public weeklyTarget: number,
        public factor: number,
        public startingYear: number,
        public startingWeek: number)
    { }
}