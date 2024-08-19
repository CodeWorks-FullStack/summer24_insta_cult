import { DatabaseItem } from "./DatabaseItem"

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
    this.leader = data.leader
  }
}

const data = {
  "name": "Big Hat DAMES",
  "fee": 100,
  "description": "Must have hat to join, hat must be smaller than the leader's. Hair optional.",
  "coverImg": "https://images.unsplash.com/photo-1472746729193-36ad213ac4a5?q=80&w=2338&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
  "leaderId": "66c3661e7a915e94e905ccf5",
  "leader": {
    "name": "charliechaplan@charlie.chaplan",
    "picture": "https://s.gravatar.com/avatar/eca12712f7dfb7a8e3d991e087660fe9?s=480&r=pg&d=https%3A%2F%2Fcdn.auth0.com%2Favatars%2Fch.png",
    "id": "66c3661e7a915e94e905ccf5",
    "createdAt": "2024-08-19T15:35:01",
    "updatedAt": "2024-08-19T15:35:01"
  },
  "id": 1,
  "createdAt": "2024-08-19T15:44:36",
  "updatedAt": "2024-08-19T15:44:36"
}