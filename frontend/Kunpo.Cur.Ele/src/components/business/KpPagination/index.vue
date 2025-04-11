<template>
  <div class="kp-pagination">
    <el-pagination v-model:current-page="currentPage" v-model:page-size="pageSize" :page-sizes="pageSizes"
      :total="total" :layout="layout" @size-change="handleSizeChange" @current-change="handleCurrentChange" />
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'

const props = withDefaults(defineProps<{
  total: number
  currentPage?: number
  pageSize?: number
  pageSizes?: number[]
  layout?: string
}>(), {
  currentPage: 1,
  pageSize: 10,
  pageSizes: () => [10, 20, 50, 100],
  layout: 'total, sizes, prev, pager, next, jumper'
})

const emit = defineEmits<{
  (e: 'update:currentPage', page: number): void
  (e: 'update:pageSize', size: number): void
  (e: 'change', page: number, size: number): void
}>()

const currentPage = ref(props.currentPage)
const pageSize = ref(props.pageSize)

const handleSizeChange = (val: number) => {
  pageSize.value = val
  emit('update:pageSize', val)
  emit('change', currentPage.value, val)
}

const handleCurrentChange = (val: number) => {
  currentPage.value = val
  emit('update:currentPage', val)
  emit('change', val, pageSize.value)
}

// 暴露方法给父组件
defineExpose({
  currentPage,
  pageSize
})
</script>

<style scoped>
.kp-pagination {
  display: flex;
  justify-content: flex-end;
  margin-top: 16px;
}
</style>