<template>
  <div class="kp-query">
    <el-form ref="formRef" :model="formData" :inline="true" :label-width="labelWidth" class="query-form">
      <slot :form="formData" />
      <el-form-item>
        <el-button type="primary" @click="handleSearch">
          {{ t('common.search') }}
        </el-button>
        <el-button @click="handleReset">
          {{ t('common.reset') }}
        </el-button>
      </el-form-item>
    </el-form>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { useI18n } from 'vue-i18n'
import type { FormInstance } from 'element-plus'

const props = withDefaults(defineProps<{
  labelWidth?: string
  initialValues?: Record<string, any>
}>(), {
  labelWidth: '100px',
  initialValues: () => ({})
})

const emit = defineEmits<{
  (e: 'search', values: Record<string, any>): void
  (e: 'reset'): void
}>()

const { t } = useI18n()
const formRef = ref<FormInstance>()
const formData = ref<Record<string, any>>({ ...props.initialValues })

// 搜索
const handleSearch = async () => {
  if (!formRef.value) return
  await formRef.value.validate()
  emit('search', formData.value)
}

// 重置
const handleReset = () => {
  if (!formRef.value) return
  formRef.value.resetFields()
  emit('reset')
}

// 暴露方法给父组件
defineExpose({
  formRef,
  formData
})
</script>

<style scoped>
.kp-query {
  background-color: #fff;
  padding: 16px;
  border-radius: 4px;
  margin-bottom: 16px;
}

.query-form {
  display: flex;
  flex-wrap: wrap;
  gap: 16px;
}
</style>