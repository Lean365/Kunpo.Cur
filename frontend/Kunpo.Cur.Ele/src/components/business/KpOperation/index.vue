<template>
  <div class="kp-operation">
    <el-button v-if="showEdit" type="primary" link @click="() => handleEdit(row, index)">
      {{ t('common.edit') }}
    </el-button>
    <el-button v-if="showDelete" type="danger" link @click="() => handleDelete(row, index)">
      {{ t('common.delete') }}
    </el-button>
    <slot />
  </div>
</template>

<script setup lang="ts">
import { useI18n } from 'vue-i18n'

const props = withDefaults(defineProps<{
  showEdit?: boolean
  showDelete?: boolean
  row: any
  index: number
}>(), {
  showEdit: true,
  showDelete: true
})

const emit = defineEmits<{
  (e: 'edit', row: any, index: number): void
  (e: 'delete', row: any, index: number): void
}>()

const { t } = useI18n()

const handleEdit = (row: any, index: number) => {
  emit('edit', row, index)
}

const handleDelete = (row: any, index: number) => {
  emit('delete', row, index)
}
</script>

<style scoped>
.kp-operation {
  display: flex;
  align-items: center;
  gap: 8px;
}
</style>