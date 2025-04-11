<template>
  <a-select v-model:value="modelValue" :loading="loading" :placeholder="placeholder" :allowClear="allowClear"
    :disabled="disabled" @change="handleChange">
    <a-select-option v-for="item in options" :key="item.value" :value="item.value">
      {{ item.label }}
    </a-select-option>
  </a-select>
</template>

<script lang="ts" setup>
import { ref, onMounted, watch } from 'vue'
import type { SelectProps } from 'ant-design-vue'

interface KpDictOption {
  label: string
  value: string | number
  disabled?: boolean
}

const props = withDefaults(defineProps<{
  dictType: string
  modelValue?: string | number
  placeholder?: string
  allowClear?: boolean
  disabled?: boolean
}>(), {
  placeholder: '请选择',
  allowClear: true,
  disabled: false
})

const emit = defineEmits<{
  (e: 'update:modelValue', value: string | number): void
  (e: 'change', value: string | number, option: KpDictOption | KpDictOption[]): void
}>()

const loading = ref(false)
const options = ref<KpDictOption[]>([])

const loadDictData = async () => {
  loading.value = true
  try {
    // TODO: 替换为实际的字典数据获取接口
    const response = await fetch(`/api/dict/${props.dictType}`)
    const data = await response.json()
    options.value = data.map((item: any) => ({
      label: item.dictLabel,
      value: item.dictValue,
      disabled: item.status === '1' // 假设 status === '1' 表示禁用
    }))
  } catch (error) {
    console.error('加载字典数据失败:', error)
  } finally {
    loading.value = false
  }
}

const handleChange: SelectProps['onChange'] = (value, option) => {
  const selectedValue = value as string | number | undefined
  emit('update:modelValue', selectedValue ?? '')
  emit('change', selectedValue ?? '', option as KpDictOption | KpDictOption[])
}

watch(() => props.dictType, () => {
  loadDictData()
})

onMounted(() => {
  loadDictData()
})
</script>