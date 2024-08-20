import { Cult } from "./Cult.js"

export class JoinedCult extends Cult {
  constructor(data) {
    super(data)
    this.cultId = data.cultId
    this.cultMemberId = data.cultMemberId
    this.accountId = data.accountId
  }
}
