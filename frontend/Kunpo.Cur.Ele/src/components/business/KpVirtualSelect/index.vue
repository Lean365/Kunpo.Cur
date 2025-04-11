<template>
  <el-select v-model="modelValue" v-bind="$attrs" :placeholder="placeholder" :clearable="clearable" :multiple="multiple"
    :disabled="disabled" :filterable="filterable" :remote="remote" :remote-method="remoteMethod" :loading="loading"
    @change="handleChange">
    <el-option v-for="item in visibleOptions" :key="item.value" :label="item.label" :value="item.value">
      <slot name="option" :item="item">
        {{ item.label }}
      </slot>
    </el-option>
  </el-select>
</template>

<script setup lang="ts">
import { ref, computed, watch } from 'vue'

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
  itemHeight?: number
  visibleCount?: number
}>(), {
  placeholder: '请选择',
  clearable: true,
  multiple: false,
  disabled: false,
  filterable: false,
  remote: false,
  itemHeight: 34,
  visibleCount: 10
})

const emit = defineEmits<{
  (e: 'update:modelValue', value: any): void
  (e: 'change', value: any): void
}>()

const loading = ref(false)
const scrollTop = ref(0)

// 计算可见选项
const visibleOptions = computed(() => {
  const startIndex = Math.floor(scrollTop.value / props.itemHeight)
  const endIndex = startIndex + props.visibleCount
  return props.options.slice(startIndex, endIndex)
})

// 计算总高度
const totalHeight = computed(() => {
  return props.options.length * props.itemHeight
})

// 处理滚动
const handleScroll = (e: Event) => {
  const target = e.target as HTMLElement
  scrollTop.value = target.scrollTop
}

// 处理选择变化
const handleChange = (value: any) => {
  emit('update:modelValue', value)
  emit('change', value)
}

// 滚动到指定选项
const scrollToOption = (value: any) => {
  const index = props.options.findIndex(item => item.value === value)
  if (index > -1) {
    scrollTop.value = index * props.itemHeight
  }
}

// 监听值变化，自动滚动到选中项
watch(() => props.modelValue, (val) => {
  if (val) {
    scrollToOption(val)
  }
})

// 暴露方法给父组件
defineExpose({
  loading,
  scrollToOption
})
</script>

<style scoped>
.el-select-dropdown__wrap {
  max-height: v-bind('visibleCount * itemHeight + "px"');
  overflow-y: auto;
}
</style>