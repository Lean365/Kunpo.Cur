<template>
  <a-breadcrumb class="kp-breadcrumb">
    <a-breadcrumb-item v-for="(item, index) in breadcrumbs" :key="index">
      <router-link v-if="item.path" :to="item.path">{{ item.title }}</router-link>
      <span v-else>{{ item.title }}</span>
    </a-breadcrumb-item>
  </a-breadcrumb>
</template>

<script setup lang="ts">
import { computed } from 'vue'
import { useRoute } from 'vue-router'
import { useI18n } from 'vue-i18n'

const { t } = useI18n()
const route = useRoute()

const breadcrumbs = computed(() => {
  const matched = route.matched
  return matched.map(item => ({
    title: item.meta?.title ? t(String(item.meta.title)) : '',
    path: item.path
  }))
})
</script>

<style lang="less" scoped>
.kp-breadcrumb {
  margin-bottom: 16px;
}
</style>