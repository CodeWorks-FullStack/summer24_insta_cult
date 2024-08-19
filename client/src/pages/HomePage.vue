<script setup>

</script>

<template>
  <section class="">
    <button class="btn btn-outline-danger text-light fw-bold megrim-font fs-1">
      Join A Cult?
    </button>
    <button class="btn btn-outline-danger text-light fw-bold megrim-font fs-1">
      Start A Cult?
    </button>
  </section>
</template>

<style lang="scss">
section {
  min-height: var(--main-height);
  display: flex;
  align-items: center;
  justify-content: center;
  gap: 2rem;
}

body {
  background-image: url(https://images.unsplash.com/photo-1483982258113-b72862e6cff6?q=80&w=2340&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D);
  background-size: cover;
}

#app {
  backdrop-filter: grayscale(1);
}
</style>
