export class ProgressHelper {

    // Returns a new object containing parsed year and week for an HTML input element.
    // weekToParse has the following format: "2018-W02"
    public static parseHtmlWeek(weekToParse: string): any {
        // "2018-W35"
        var yearRegex = new RegExp("^(\\d{4})");     // first four digits    -> selected year
        var weekRegex = new RegExp("W(\\d{2})$");    // two digits after W   -> selected week

        var selectedYear = yearRegex.exec(weekToParse);
        var selectedWeek = weekRegex.exec(weekToParse);

        var year: number = 2018;    // fallback
        if (selectedYear != null)
            year = Number(selectedYear[1]);

        var week: number = 1;       // fallback
        if (selectedWeek != null)
            week = Number(selectedWeek[1]);

        //return [year, week];
        return { year: year, week: week };
    }

    public static getWeekOfTheYear(d: Date): number {
        // Copy date so don't modify original
        d = new Date(+d);
        d.setHours(0, 0, 0);

        // Set to nearest Thursday: current date + 4 - current day number
        // Make Sunday's day number 7
        d.setDate(d.getDate() + 4 - (d.getDay() || 7));

        // Get first day of year
        var yearStart = new Date(d.getFullYear(), 0, 1);

        // Calculate full weeks to nearest Thursday
        var weekNo = Math.ceil((((d.valueOf() - yearStart.valueOf()) / 86400000) + 1) / 7);

        // Return array of year and week number
        return weekNo;
    }

}