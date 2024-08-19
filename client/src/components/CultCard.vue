<script setup>
import { Cult } from '@/models/Cult.js';

defineProps({ cult: Cult })
</script>


<template>
  <div class="cult-card text-light">
    <div class="p-3 d-flex align-items-center gap-2">
      <img :src="cult.leader.picture" :alt="cult.leader.name" class="profile-img">
      <p class="megrim-font fs-3 mb-0">{{ cult.leader.trimmedName }}</p>
    </div>
    <img :src="cult.coverImg" :alt="'Cover image of the ' + cult.name + ' cult.'" class="cult-cover-img">
    <div class="p-3">
      <p class="fs-4 megrim-font">{{ cult.name }}</p>
      <p>{{ cult.description }}</p>
      <div class="text-end">
        <button class="btn btn-danger text-light fs-5">See More</button>
      </div>
    </div>
  </div>
</template>


<style scoped>
.cult-card {
  background-color: #312F2F;
  border: 2px solid rgb(119, 0, 0);
  box-shadow: 2px 2px 15px rgb(208, 1, 1);
  border-radius: 15px;
}

.profile-img {
  aspect-ratio: 1/1;
  height: 15vh;
  border-radius: 50%;
  filter: grayscale(1);
}

.cult-cover-img {
  width: 100%;
  filter: grayscale(1);
  height: 45vh;
  object-fit: cover;
}
</style>