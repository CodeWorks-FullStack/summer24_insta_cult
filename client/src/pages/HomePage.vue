<script setup>
import ModalComponent from '@/components/ModalComponent.vue'

</script>

<template>
  <section>
    <div class="text-center">
      <RouterLink to="cults">
        <button
          class="btn d-block d-md-inline-block btn-outline-danger text-light fw-bold megrim-font fs-1 mb-3 mb-md-0 me-md-2">
          Join A Cult?
        </button>
      </RouterLink>
      <button class="btn d-block d-md-inline-block btn-outline-danger text-light fw-bold megrim-font fs-1"
        data-bs-toggle="modal" data-bs-target="#createCultModal">
        Start A Cult?
      </button>
    </div>
  </section>
  <ModalComponent modalId="createCultModal">
    <template #modalHeader>Create Cult</template>
    <template #modalBody>FORM</template>
  </ModalComponent>
</template>

<style lang="scss">
section {
  min-height: var(--main-height);
  display: flex;
  align-items: center;
  justify-content: center;
}

body {
  background-image: url(https://images.unsplash.com/photo-1483982258113-b72862e6cff6?q=80&w=2340&auto=format&fit=crop&ixlib=rb-4.0.3&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D);
  background-size: cover;
  z-index: -2;
}

body::after {
  z-index: -1;
  content: '';
  position: fixed;
  top: 0;
  left: 0;
  height: 100dvh;
  width: 100dvw;
  pointer-events: none;
  backdrop-filter: grayscale(1);
}
</style>
