<script setup>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import Pop from '@/utils/Pop.js';
import { cultMembersService } from '@/services/CultMembersService.js';
import CultCard from '@/components/CultCard.vue';

const account = computed(() => AppState.account)

const cults = computed(() => AppState.myJoinedCults)

onMounted(getMyJoinedCults)

async function getMyJoinedCults() {
  try {
    await cultMembersService.getMyJoinedCults()
  }
  catch (error) {
    Pop.error(error);
  }
}

</script>

<template>
  <div class="container-fluid">
    <section class="row">
      <div class="col-12 p-5">
        <h1 class="megrim-font">Cults You Are a member of</h1>
      </div>
    </section>
    <section class="row">
      <div v-for="cult in cults" :key="cult.id" class="col-md-7 col-12 m-auto mb-5">
        <CultCard :cult="cult" />
      </div>
    </section>
  </div>
</template>

<style scoped lang="scss"></style>
