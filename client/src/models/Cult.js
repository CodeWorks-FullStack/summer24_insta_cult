import { DatabaseItem } from "./DatabaseItem"
import { Profile } from "./Profile.js"

export class Cult extends DatabaseItem {
  constructor(data) {
    super(data)
    // NOTE these 3 properties are now inherited
    // this.id = data.id
    // this.createdAt = new Date(data.createdAt)
    // this.updatedAt = new Date(data.updatedAt)

    this.name = data.name
    this.fee = data.fee
    this.description = data.description
    this.coverImg = data.coverImg
    this.leaderId = data.leaderId
    this.leader = new Profile(data.leader)
  }
}