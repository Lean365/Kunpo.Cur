<template>
  <i :class="[
    'kp-font',
    `kp-font-${name}`,
    { 'is-spin': spin },
    { 'is-pulse': pulse }
  ]" :style="{
      fontSize: size ? `${size}px` : undefined,
      color: color
    }" />
</template>

<script setup lang="ts">
defineProps<{
  name: string
  size?: number
  color?: string
  spin?: boolean
  pulse?: boolean
}>()
</script>

<style scoped>
.kp-font {
  display: inline-block;
  font-style: normal;
  line-height: 1;
  text-align: center;
  text-transform: none;
  text-rendering: optimizeLegibility;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
}

.is-spin {
  animation: kp-spin 1s infinite linear;
}

.is-pulse {
  animation: kp-pulse 2s infinite;
}

@keyframes kp-spin {
  from {
    transform: rotate(0deg);
  }

  to {
    transform: rotate(360deg);
  }
}

@keyframes kp-pulse {
  0% {
    transform: scale(1);
  }

  50% {
    transform: scale(1.2);
  }

  100% {
    transform: scale(1);
  }
}
</style>