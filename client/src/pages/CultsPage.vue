<script setup>
import { AppState } from '@/AppState.js';
import { cultsService } from '@/services/CultsService.js';
import Pop from '@/utils/Pop.js';
import { computed, onMounted } from 'vue';
import CultCard from '@/components/CultCard.vue'

const cults = computed(() => AppState.cults)

onMounted(getAllCults)

async function getAllCults() {
  try {
    await cultsService.getAllCults()
  } catch (error) {
    Pop.error(error)
  }
}
</script>


<template>
  <div class="container">
    <section class="row">
      <div class="col-12">
        <div class="text-overline">
          <p class="megrim-font fs-3">Cults Near You</p>
        </div>
      </div>
    </section>

    <section class="row">
      <div v-for="cult in cults" :key="cult.id" class="col-md-7 col-12 m-auto mb-5">
        <CultCard :cult="cult" />
      </div>
    </section>
  </div>
</template>


<style scoped lang="scss">
.text-overline {
  padding: 1rem;
  width: fit-content;
  border-top: 3px solid var(--bs-light);
}
</style>