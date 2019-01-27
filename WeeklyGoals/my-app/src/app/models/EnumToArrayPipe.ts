import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'keyValuePairs'
})
export class KeyValuePairs implements PipeTransform {
  transform(data: Object): any {
    const keyValuePairs = [];
    for (const enumMember in data) {
      if (!isNaN(parseInt(enumMember, 10))) {
        keyValuePairs.push({ key: enumMember, value: data[enumMember] });
      }
    }
    return keyValuePairs;
  }
}
