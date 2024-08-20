<script setup>
import ModalComponent from '@/components/ModalComponent.vue'
import CultForm from '@/components/CultForm.vue'
import { computed } from 'vue';
import { AppState } from '@/AppState.js';

const account = computed(() => AppState.account)


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
      <button v-if="account"
        class="btn d-block d-md-inline-block btn-outline-danger text-light fw-bold megrim-font fs-1"
        data-bs-toggle="modal" data-bs-target="#createCultModal">
        Start A Cult?
      </button>
    </div>
  </section>
  <ModalComponent modalId="createCultModal">
    <template #modalHeader>Create Cult</template>
    <template #modalBody>
      <CultForm />
    </template>
  </ModalComponent>
</template>

<style scoped lang="scss">
section {
  min-height: var(--main-height);
  display: flex;
  align-items: center;
  justify-content: center;
}
</style>
