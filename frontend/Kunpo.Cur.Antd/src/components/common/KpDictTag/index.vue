<template>
  <a-tag v-if="tag" :color="tag.color">
    {{ tag.label }}
  </a-tag>
  <span v-else>{{ value }}</span>
</template>

<script lang="ts" setup>
import { ref, onMounted, watch } from 'vue'

interface KpDictTag {
  label: string
  value: string | number
  color?: string
  status?: string
}

const props = defineProps<{
  dictType: string
  value: string | number
}>()

const tag = ref<KpDictTag | null>(null)

const loadDictData = async () => {
  if (!props.value) {
    tag.value = null
    return
  }

  try {
    // TODO: 替换为实际的字典数据获取接口
    const response = await fetch(`/api/dict/${props.dictType}`)
    const data = await response.json()

    const dictItem = data.find((item: any) => item.dictValue === props.value)
    if (dictItem) {
      tag.value = {
        label: dictItem.dictLabel,
        value: dictItem.dictValue,
        color: getTagColor(dictItem.status),
        status: dictItem.status
      }
    } else {
      tag.value = null
    }
  } catch (error) {
    console.error('加载字典数据失败:', error)
    tag.value = null
  }
}

const getTagColor = (status?: string): string => {
  // 根据状态返回不同的标签颜色
  const colorMap: Record<string, string> = {
    '0': 'success',    // 正常
    '1': 'error',      // 停用
    '2': 'processing', // 进行中
    '3': 'warning',    // 警告
    'default': ''      // 默认
  }
  return status ? (colorMap[status] || colorMap.default) : colorMap.default
}

watch(() => [props.dictType, props.value], () => {
  loadDictData()
})

onMounted(() => {
  loadDictData()
})
</script>