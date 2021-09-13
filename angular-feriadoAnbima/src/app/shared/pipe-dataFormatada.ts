import { Pipe, PipeTransform } from "@angular/core";

@Pipe ({
  name : "dataFormata"
})

export class DataFormata implements PipeTransform {
  transform( dataPassada : string) : string{
    let data = new Date(dataPassada);
    return `${data.getDate()}/${data.getMonth() + 1}/${data.getFullYear()}`
  }
}