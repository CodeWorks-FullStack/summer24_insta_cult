<script setup>
import { computed, onMounted } from 'vue';
import { AppState } from '../AppState.js';
import Pop from '@/utils/Pop.js';
import { cultMembersService } from '@/services/CultMembersService.js';

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
      <div class="col-12">
        <h1>Cults You Are a member of</h1>
      </div>
    </section>
    <section class="row">
      {{ cults }}
    </section>
  </div>
</template>

<style scoped lang="scss"></style>
