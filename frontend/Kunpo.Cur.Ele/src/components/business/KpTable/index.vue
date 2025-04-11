<template>
  <div class="kp-table">
    <!-- 工具栏 -->
    <div v-if="$slots.toolbar" class="table-toolbar">
      <slot name="toolbar" />
    </div>

    <!-- 表格 -->
    <el-table v-bind="$attrs" :data="data" v-loading="loading" @selection-change="handleSelectionChange">
      <!-- 选择列 -->
      <el-table-column v-if="showSelection" type="selection" width="55" align="center" />

      <!-- 序号列 -->
      <el-table-column v-if="showIndex" type="index" label="序号" width="60" align="center" />

      <!-- 数据列 -->
      <slot />

      <!-- 操作列 -->
      <el-table-column v-if="$slots.operation" :label="t('common.operation')" :width="operationWidth" align="center"
        fixed="right">
        <template #default="scope">
          <slot name="operation" :row="scope.row" :index="scope.$index" />
        </template>
      </el-table-column>
    </el-table>

    <!-- 分页 -->
    <div v-if="showPagination" class="table-pagination">
      <el-pagination v-model:current-page="currentPage" v-model:page-size="pageSize" :page-sizes="[10, 20, 50, 100]"
        :total="total" layout="total, sizes, prev, pager, next, jumper" @size-change="handleSizeChange"
        @current-change="handleCurrentChange" />
    </div>
  </div>
</template>

<script setup lang="ts">
import { ref, computed } from 'vue'
import { useI18n } from 'vue-i18n'

const props = withDefaults(defineProps<{
  data: any[]
  total?: number
  showSelection?: boolean
  showIndex?: boolean
  showPagination?: boolean
  operationWidth?: number
}>(), {
  total: 0,
  showSelection: false,
  showIndex: false,
  showPagination: true,
  operationWidth: 150
})

const emit = defineEmits<{
  (e: 'update:page', page: number): void
  (e: 'update:pageSize', pageSize: number): void
  (e: 'selection-change', selection: any[]): void
}>()

const { t } = useI18n()

const loading = ref(false)
const currentPage = ref(1)
const pageSize = ref(10)

const handleSizeChange = (val: number) => {
  pageSize.value = val
  emit('update:pageSize', val)
}

const handleCurrentChange = (val: number) => {
  currentPage.value = val
  emit('update:page', val)
}

const handleSelectionChange = (selection: any[]) => {
  emit('selection-change', selection)
}

// 暴露方法给父组件
defineExpose({
  loading,
  currentPage,
  pageSize
})
</script>

<style scoped>
.kp-table {
  background-color: #fff;
  padding: 16px;
  border-radius: 4px;
}

.table-toolbar {
  margin-bottom: 16px;
}

.table-pagination {
  margin-top: 16px;
  display: flex;
  justify-content: flex-end;
}
</style>