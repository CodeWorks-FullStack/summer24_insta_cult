<script setup>
import { cultsService } from '@/services/CultsService.js';
import Pop from '@/utils/Pop.js';
import { watchEffect } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute()


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
  <h1>Cult details Page</h1>
</template>


<style scoped></style>