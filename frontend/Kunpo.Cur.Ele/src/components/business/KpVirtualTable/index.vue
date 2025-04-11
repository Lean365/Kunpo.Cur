<template>
  <div ref="containerRef" class="kp-virtual-table" @scroll="handleScroll">
    <div ref="contentRef" class="virtual-table-content" :style="{ height: `${totalHeight}px` }">
      <div class="virtual-table-inner" :style="{ transform: `translateY(${offsetY}px)` }">
        <el-table :data="visibleData" v-bind="$attrs" :height="height" @selection-change="handleSelectionChange">
          <slot />
        </el-table>
      </div>
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, computed, onMounted, onUnmounted } from 'vue'

const props = withDefaults(defineProps<{
  data: any[]
  height?: number
  rowHeight?: number
  bufferSize?: number
}>(), {
  height: 400,
  rowHeight: 48,
  bufferSize: 5
})

const emit = defineEmits<{
  (e: 'selection-change', selection: any[]): void
}>()

const containerRef = ref<HTMLElement>()
const contentRef = ref<HTMLElement>()
const scrollTop = ref(0)

// 计算可见区域的行数
const visibleCount = computed(() => {
  return Math.ceil(props.height / props.rowHeight) + props.bufferSize * 2
})

// 计算总高度
const totalHeight = computed(() => {
  return props.data.length * props.rowHeight
})

// 计算起始索引
const startIndex = computed(() => {
  const start = Math.floor(scrollTop.value / props.rowHeight) - props.bufferSize
  return Math.max(0, start)
})

// 计算结束索引
const endIndex = computed(() => {
  const end = startIndex.value + visibleCount.value
  return Math.min(props.data.length, end)
})

// 计算偏移量
const offsetY = computed(() => {
  return startIndex.value * props.rowHeight
})

// 计算可见数据
const visibleData = computed(() => {
  return props.data.slice(startIndex.value, endIndex.value)
})

// 处理滚动
const handleScroll = (e: Event) => {
  const target = e.target as HTMLElement
  scrollTop.value = target.scrollTop
}

// 处理选择变化
const handleSelectionChange = (selection: any[]) => {
  emit('selection-change', selection)
}

// 滚动到指定行
const scrollToRow = (index: number) => {
  if (!containerRef.value) return
  containerRef.value.scrollTop = index * props.rowHeight
}

// 暴露方法给父组件
defineExpose({
  scrollToRow
})
</script>

<style scoped>
.kp-virtual-table {
  position: relative;
  overflow: auto;
  height: v-bind('height + "px"');
}

.virtual-table-content {
  position: relative;
  width: 100%;
}

.virtual-table-inner {
  position: absolute;
  left: 0;
  right: 0;
  will-change: transform;
}
</style>