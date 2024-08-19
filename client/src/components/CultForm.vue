<script setup>
import { cultsService } from '@/services/CultsService.js';
import Pop from '@/utils/Pop.js';
import { Modal } from 'bootstrap';
import { ref } from 'vue';


const editableCultData = ref({
  name: '',
  fee: 0.00,
  coverImg: '',
  description: ''
})


async function createCult() {
  try {
    await cultsService.createCult(editableCultData.value)
    Modal.getOrCreateInstance('#createCultModal').hide()
    editableCultData.value = {
      name: '',
      fee: 0.00,
      coverImg: '',
      description: ''
    }
  } catch (error) {
    Pop.error(error)
  }
}
</script>


<template>
  <form @submit.prevent="createCult()">
    <div class="mb-3">
      <label for="name">Cult Name</label>
      <input v-model="editableCultData.name" type="text" id="name" maxlength="255" required>
    </div>
    <div class="mb-3">
      <label for="fee">Cult Fee</label>
      <input v-model="editableCultData.fee" type="number" id="fee" min="0.00" max="9999999.99" required>
    </div>
    <div class="mb-3">
      <label for="coverImg">Cult CoverImg</label>
      <input v-model="editableCultData.coverImg" type="url" id="coverImg" maxlength="3000" required>
    </div>
    <div class="mb-3">
      <label for="description">Cult Description</label>
      <textarea v-model="editableCultData.description" id="description" required maxlength="65535"></textarea>
    </div>
    <div class="text-end">
      <button type="submit" class="btn btn-danger megrim-font">
        Submit
      </button>
    </div>
  </form>
</template>


<style scoped>
label {
  display: block;
  font-family: "Megrim", system-ui;
  font-style: normal;
  font-weight: bold;
}

textarea,
input {
  width: 100%;
  border-radius: 12px;
  border: 1px solid var(--bs-dark);
  background-color: var(--bs-danger);
}
</style>