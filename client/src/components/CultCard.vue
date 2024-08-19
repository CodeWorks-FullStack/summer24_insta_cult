<script setup>
import { Cult } from '@/models/Cult.js';

defineProps({ cult: Cult })
</script>


<template>
  <div>{{ cult.name }}</div>
</template>


<style scoped></style>