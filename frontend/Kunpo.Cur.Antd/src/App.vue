<template>
  <a-config-provider :locale="localeStore.antLocale" :theme="{ algorithm: themeStore.algorithm }">
    <router-view />
  </a-config-provider>
</template>

<script lang="ts" setup>
import { useLocaleStore } from '@/stores/locale'
import { useThemeStore } from '@/stores/theme'

const localeStore = useLocaleStore()
const themeStore = useThemeStore()

localeStore.initLocale()
themeStore.initTheme()
</script>

<style>
#app {
  width: 100%;
  height: 100%;
}
</style>