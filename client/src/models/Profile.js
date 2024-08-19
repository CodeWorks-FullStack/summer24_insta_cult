import { DatabaseItem } from "./DatabaseItem.js";



export class Profile extends DatabaseItem {
  constructor(data) {
    super(data);
    this.name = data.name;
    this.picture = data.picture;
  }

  get trimmedName() {
    const lastIndexOfAt = this.name.lastIndexOf('@')
    return lastIndexOfAt > -1 ? this.name.substring(0, lastIndexOfAt) : this.name
  }
}
