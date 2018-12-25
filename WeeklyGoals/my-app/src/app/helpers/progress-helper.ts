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



  // returns the date in the format needed by the html <input type='week' /> tag.
  public static convertDateToHtmlInputFormat(date: Date): string {
    var currentYear = date.getFullYear();
    var currentWeek = ProgressHelper.getWeekOfTheYear(date);

    // formatting needed for html tag - <input type='week' />
    return `${currentYear}-W${this.pad(currentWeek, 2)}`;
  }

  // Returns a new string of a specified length in which the beginning of the number is padded with zeros.
  private static pad(number: number, length: number): string {
    var s = number.toString();
    while (s.length < length)
      s = "0" + s;
    return s;
  }

}
