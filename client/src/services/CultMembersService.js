import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { Cultist } from "@/models/Cultist.js"
import { JoinedCult } from "@/models/JoinedCult.js"

class CultMembersService {
  async getMyJoinedCults() {
    const response = await api.get('account/cultMembers')
    logger.log('GOT MY JOINED CULTS', response.data)
    AppState.myJoinedCults = response.data.map(cultPOJO => new JoinedCult(cultPOJO))
  }
  async removeCultMember(cultMemberId) {
    const response = await api.delete(`api/cultMembers/${cultMemberId}`)
    logger.log("REMOVED CULT MEMBER", response.data)
    const cultistIndex = AppState.cultists.findIndex(cultist => cultist.cultMemberId == cultMemberId)
    if (cultistIndex == -1) throw new Error("You messed up the findIndex, dawg")
    AppState.cultists.splice(cultistIndex, 1)
  }
  async createCultMember(cultMemberData) {
    const response = await api.post('api/cultMembers', cultMemberData)
    logger.log('CREATED CULT MEMBER', response.data)
    AppState.cultists.push(new Cultist(response.data))
  }
  async getCultistsByCultId(cultId) {
    // AppState.cultists = [] // <--rad
    AppState.cultists.length = 0 //<--radder
    const response = await api.get(`api/cults/${cultId}/cultMembers`)
    logger.log('GOT CULTISTS')
    AppState.cultists = response.data.map(cultistPOJO => new Cultist(cultistPOJO))
  }
}

export const cultMembersService = new CultMembersService()