import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root',
})
export class Utilities
{
  public getBoolean(value) {
    switch (value) {
    case true:
    case "true":
    case 1:
    case "1":
    case "on":
    case "yes":
      return true;
    default:
      return false;
    }
  }
}
