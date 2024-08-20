<script setup>
import { AppState } from '@/AppState.js';
import { cultMembersService } from '@/services/CultMembersService.js';
import { cultsService } from '@/services/CultsService.js';
import Pop from '@/utils/Pop.js';
import { computed, watchEffect } from 'vue';
import { useRoute } from 'vue-router';

const route = useRoute()

const account = computed(() => AppState.account)

const cult = computed(() => AppState.activeCult)

const cultists = computed(() => AppState.cultists)

const isCultist = computed(() => cultists.value.some(cultist => account.value?.id == cultist.id))

watchEffect(() => {
  getCultById(route.params.cultId)
  getCultistsByCultId(route.params.cultId)
})

// onMounted(() => {
//   getCultById(route.params.cultId)
// })

async function getCultById(cultId) {
  try {
    await cultsService.getCultById(cultId)
  }
  catch (error) {
    Pop.error(error);
  }
}

async function getCultistsByCultId(cultId) {
  try {
    await cultMembersService.getCultistsByCultId(cultId)
  }
  catch (error) {
    Pop.error(error);
  }
}

async function createCultMember() {
  try {
    const cultMemberData = { cultId: route.params.cultId }
    await cultMembersService.createCultMember(cultMemberData)
  }
  catch (error) {
    Pop.error(error);
  }
}

async function removeCultMember(cultMemberId) {
  try {
    const wantsToDelete = await Pop.confirm("Are you sure that this cult member should be removed????")
    if (!wantsToDelete) return
    await cultMembersService.removeCultMember(cultMemberId)
  }
  catch (error) {
    Pop.error(error);
  }
}

</script>


<template>
  <div v-if="cult" class="container-fluid">
    <section class="row cult-img-bg" :style="{ backgroundImage: `url(${cult.coverImg})` }">
      <div class="col-12 h-100 blur d-flex align-items-center">
        <div class="p-5">
          <h1 class="amarante-font">{{ cult.name }}</h1>
          <button v-if="account && !isCultist" @click="createCultMember()"
            class="btn btn-outline-danger bg-dark amarante-font fs-1">
            JOIN
          </button>
          <button v-else-if="isCultist" @click="Pop.toast('Nice try loser')"
            class="btn btn-outline-danger bg-dark amarante-font fs-1" disabled>
            LEAVE
          </button>
        </div>
      </div>
    </section>
    <section class="row border-top border-dark border-5">
      <div class="col-12 col-md-6 order-md-2">
        <div class="mb-3 p-3">
          <h2 class="amarante-font">Cult Leader</h2>
          <img :src="cult.leader.picture" :alt="cult.leader.name" class="cult-leader-img round-picture"
            :title="cult.leader.name">
        </div>
        <div class="p-3">
          <h3 class="amarante-font">Members: {{ cultists.length }}</h3>
          <div class="d-flex gap-2">
            <div v-for="cultist in cultists" :key="cultist.cultMemberId" class="position-relative">
              <img :src="cultist.picture" :alt="cultist.name" :title="cultist.name"
                class="cult-member-img round-picture">
              <i v-if="cult.leaderId == account?.id" @click="removeCultMember(cultist.cultMemberId)"
                class="mdi mdi-close-circle fs-2 text-danger remove-cultist-icon" role="button"
                :title="`Remove ${cultist.name} from ${cult.name}`"></i>
            </div>
          </div>
        </div>
      </div>
      <div class="col-12 col-md-6 order-md-1">
        <div>
          <p>{{ cult.description }}</p>
        </div>
      </div>
    </section>
  </div>
  <div v-else class="container-fluid">
    <section class="row">
      <div class="col-12">
        <h1 class="text-center my-5">
          Loading... <i v-for="icon in 3" :key="icon" class="mdi mdi-loading mdi-spin"></i>
        </h1>
      </div>
    </section>
  </div>
</template>


<style scoped>
.cult-img-bg {
  height: 60dvh;
  background-size: cover;
  background-position: center;
  color: rgb(70, 0, 0);
  text-shadow: 0 0 20px rgb(255, 3, 3);
  -webkit-text-stroke-width: 3px;
  -webkit-text-stroke-color: rgb(188, 0, 0);
}

.blur {
  backdrop-filter: blur(6px) grayscale(1);
}

.round-picture {
  aspect-ratio: 1/1;
  border-radius: 50%;
}

.cult-leader-img {
  height: 100px;
}

.cult-member-img {
  height: 75px;
}

.remove-cultist-icon {
  position: absolute;
  top: -8px;
  right: -4px;
}
</style>