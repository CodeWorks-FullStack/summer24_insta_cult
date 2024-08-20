import { reactive } from 'vue'
import { Cult } from './models/Cult.js'
import { Cultist } from './models/Cultist.js'
import { JoinedCult } from './models/JoinedCult.js'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  /**@type {import('@bcwdev/auth0provider-client').Identity} */
  identity: null,
  /** @type {import('./models/Account.js').Account} user info from the database*/
  account: null,
  /** @type {Cult[]}*/
  cults: [],
  /** @type {Cult}*/
  activeCult: null,
  /** @type {Cultist[]}*/
  cultists: [],
  /** @type {JoinedCult[]}*/
  myJoinedCults: []
})

