<template>
  <el-dialog v-model="visible" :title="title" :width="width" :top="top" :modal="modal" :append-to-body="appendToBody"
    :close-on-click-modal="closeOnClickModal" :close-on-press-escape="closeOnPressEscape" :show-close="showClose"
    :destroy-on-close="destroyOnClose" @close="handleClose">
    <slot />

    <template #footer>
      <slot name="footer">
        <el-button @click="handleCancel">
          {{ t('common.cancel') }}
        </el-button>
        <el-button type="primary" @click="handleConfirm">
          {{ t('common.confirm') }}
        </el-button>
      </slot>
    </template>
  </el-dialog>
</template>

<script setup lang="ts">
import { ref, watch } from 'vue'
import { useI18n } from 'vue-i18n'

const props = withDefaults(defineProps<{
  modelValue: boolean
  title?: string
  width?: string
  top?: string
  modal?: boolean
  appendToBody?: boolean
  closeOnClickModal?: boolean
  closeOnPressEscape?: boolean
  showClose?: boolean
  destroyOnClose?: boolean
}>(), {
  title: '',
  width: '50%',
  top: '15vh',
  modal: true,
  appendToBody: false,
  closeOnClickModal: false,
  closeOnPressEscape: true,
  showClose: true,
  destroyOnClose: false
})

const emit = defineEmits<{
  (e: 'update:modelValue', value: boolean): void
  (e: 'close'): void
  (e: 'cancel'): void
  (e: 'confirm'): void
}>()

const { t } = useI18n()
const visible = ref(props.modelValue)

watch(() => props.modelValue, (val) => {
  visible.value = val
})

watch(() => visible.value, (val) => {
  emit('update:modelValue', val)
})

const handleClose = () => {
  emit('close')
}

const handleCancel = () => {
  visible.value = false
  emit('cancel')
}

const handleConfirm = () => {
  emit('confirm')
}

// 暴露方法给父组件
defineExpose({
  visible
})
</script>