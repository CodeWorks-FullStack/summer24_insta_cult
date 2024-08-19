<script setup>
import { cultsService } from '@/services/CultsService.js';
import Pop from '@/utils/Pop.js';
import { onMounted } from 'vue';

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
  <h1>CULTS PAGE</h1>
</template>


<style lang="scss">
#app {
  background-color: gray;
}
</style>