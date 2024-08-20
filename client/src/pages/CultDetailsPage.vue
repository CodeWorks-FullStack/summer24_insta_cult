<script setup>
import { AppState } from '@/AppState.js';
import { cultsService } from '@/services/CultsService.js';
import Pop from '@/utils/Pop.js';
import { computed, watchEffect } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute()

const cult = computed(() => AppState.activeCult)


watchEffect(() => {
  getCultById(route.params.cultId)
})

// onMounted(() => {
//   getCultById(route.params.cultId)
// })

async function getCultById(cultId) {
  try {
    await cultsService.getCultById(cultId)
  }
  catch (error) {
    Pop.error(error);
  }
}

</script>


<template>
  <div v-if="cult" class="container-fluid">
    <section class="row cult-img-bg" :style="{ backgroundImage: `url(${cult.coverImg})` }">
      <div class="col-12 h-100 blur d-flex align-items-center">
        <div class="p-5">
          <h1 class="amarante-font">{{ cult.name }}</h1>
          <button class="btn btn-outline-danger bg-dark amarante-font fs-1">JOIN</button>
        </div>
      </div>
    </section>
  </div>
  <div v-else class="container-fluid">
    <section class="row">
      <div class="col-12">
        <h1 class="text-center my-5">
          Loading... <i v-for="icon in 3" :key="icon" class="mdi mdi-loading mdi-spin"></i>
        </h1>
      </div>
    </section>
  </div>
</template>


<style scoped>
.cult-img-bg {
  height: 60dvh;
  background-size: cover;
  background-position: center;
  color: rgb(70, 0, 0);
  text-shadow: 0 0 20px rgb(255, 3, 3);
  -webkit-text-stroke-width: 3px;
  -webkit-text-stroke-color: rgb(188, 0, 0);
}

.blur {
  backdrop-filter: blur(6px) grayscale(1);
}
</style>