<script setup>
import { watch } from 'vue';
import { AppState } from './AppState.js';
import Navbar from './components/Navbar.vue'
import { onBeforeRouteLeave, onBeforeRouteUpdate, useRoute } from 'vue-router';

const route = useRoute()

watch(() => route.name, () => {
  document.body.className = route.name?.toString().toLowerCase()
}, { immediate: true })

</script>

<template>
  <header>
    <Navbar />
  </header>
  <main>
    <router-view />
  </main>

</template>

<style lang="scss">
@import '@/assets/scss/main.scss';

:root {
  --main-height: calc(100vh - 32px - 64px);
}

footer {
  display: grid;
  place-content: center;
  height: 32px;
}
</style>
