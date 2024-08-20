import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"

class CultMembersService {
  async getCultistsByCultId(cultId) {
    const response = await api.get(`api/cults/${cultId}/cultMembers`)
    logger.log('GOT CULTISTS', response.data)
  }
}

export const cultMembersService = new CultMembersService()