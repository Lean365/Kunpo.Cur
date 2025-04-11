<template>
  <el-tag :type="type" :effect="effect" :size="size" :class="{ 'is-plain': plain }">
    {{ label }}
  </el-tag>
</template>

<script setup lang="ts">
import { computed } from 'vue'

const props = withDefaults(defineProps<{
  value: any
  options: { label: string; value: any; type?: string }[]
  type?: 'success' | 'warning' | 'info' | 'danger'
  effect?: 'dark' | 'light' | 'plain'
  size?: 'large' | 'default' | 'small'
  plain?: boolean
}>(), {
  type: 'info',
  effect: 'light',
  size: 'default',
  plain: false
})

const label = computed(() => {
  const option = props.options.find(item => item.value === props.value)
  return option?.label || props.value
})
</script>

<style scoped>
.el-tag {
  margin-right: 4px;
}
</style>