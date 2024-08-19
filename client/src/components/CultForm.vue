<script setup></script>


<template>
  <form>
    <div class="mb-3">
      <label for="name">Cult Name</label>
      <input type="text" id="name" maxlength="255" required>
    </div>
    <div class="mb-3">
      <label for="fee">Cult Fee</label>
      <input type="number" id="fee" min="0" max="9999999.99" required>
    </div>
    <div class="mb-3">
      <label for="coverImg">Cult CoverImg</label>
      <input type="url" id="coverImg" maxlength="3000" required>
    </div>
    <div class="mb-3">
      <label for="description">Cult Description</label>
      <textarea id="description" required maxlength="65535"></textarea>
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