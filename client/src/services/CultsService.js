import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { AppState } from "@/AppState.js"
import { Cult } from "@/models/Cult.js"

class CultsService {
  async createCult(cultData) {
    const response = await api.post('api/cults', cultData)
    logger.log("CREATED CULT", response.data)
  }
  async getAllCults() {
    const response = await api.get('api/cults')
    logger.log('GOT ALL CULTS 🧛🧛🧛', response.data)
    AppState.cults = response.data.map(cultPOJO => new Cult(cultPOJO))
  }
}

export const cultsService = new CultsService()