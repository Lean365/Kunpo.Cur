<template>
  <el-select v-model="modelValue" v-bind="$attrs" :placeholder="placeholder" :clearable="clearable" :multiple="multiple"
    :disabled="disabled" :filterable="filterable" :remote="remote" :remote-method="remoteMethod" :loading="loading"
    @change="handleChange">
    <el-option v-for="item in options" :key="item.value" :label="item.label" :value="item.value">
      <slot name="option" :item="item">
        {{ item.label }}
      </slot>
    </el-option>
  </el-select>
</template>

<script setup lang="ts">
import { ref } from 'vue'

interface Option {
  label: string
  value: any
  [key: string]: any
}

const props = withDefaults(defineProps<{
  modelValue: any
  options: Option[]
  placeholder?: string
  clearable?: boolean
  multiple?: boolean
  disabled?: boolean
  filterable?: boolean
  remote?: boolean
  remoteMethod?: (query: string) => void
}>(), {
  placeholder: '请选择',
  clearable: true,
  multiple: false,
  disabled: false,
  filterable: false,
  remote: false
})

const emit = defineEmits<{
  (e: 'update:modelValue', value: any): void
  (e: 'change', value: any): void
}>()

const loading = ref(false)

const handleChange = (value: any) => {
  emit('update:modelValue', value)
  emit('change', value)
}

// 暴露方法给父组件
defineExpose({
  loading
})
</script>

<style scoped>
.el-select {
  width: 100%;
}
</style>