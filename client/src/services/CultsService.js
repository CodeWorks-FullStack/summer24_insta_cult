import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"

class CultsService {
  async getAllCults() {
    const response = await api.get('api/cults')
    logger.log('GOT ALL CULTS 🧛🧛🧛', response.data)
  }
}

export const cultsService = new CultsService()