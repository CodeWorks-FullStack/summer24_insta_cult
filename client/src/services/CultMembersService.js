import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { Cultist } from "@/models/Cultist.js"

class CultMembersService {
  async createCultMember(cultMemberData) {
    const response = await api.post('api/cultMembers', cultMemberData)
    logger.log('CREATED CULT MEMBER', response.data)
  }
  async getCultistsByCultId(cultId) {
    const response = await api.get(`api/cults/${cultId}/cultMembers`)
    logger.log('GOT CULTISTS', response.data)
    AppState.cultists = response.data.map(cultistPOJO => new Cultist(cultistPOJO))
  }
}

export const cultMembersService = new CultMembersService()