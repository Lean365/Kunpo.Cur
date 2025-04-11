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

  <el-dialog v-model="dialogVisible" :title="title" :width="width" :top="top" :modal="modal"
    :append-to-body="appendToBody" :close-on-click-modal="closeOnClickModal" :close-on-press-escape="closeOnPressEscape"
    :show-close="showClose" :destroy-on-close="destroyOnClose">
    <div class="tree-select-content">
      <el-tree ref="treeRef" :data="treeData" :props="treeProps" :show-checkbox="multiple" :node-key="nodeKey"
        :default-expanded-keys="defaultExpandedKeys" :default-checked-keys="defaultCheckedKeys"
        :expand-on-click-node="false" @check="handleCheck" @node-click="handleNodeClick">
        <template #default="{ node, data }">
          <slot name="tree-node" :node="node" :data="data">
            {{ node.label }}
          </slot>
        </template>
      </el-tree>
    </div>

    <template #footer>
      <el-button @click="handleCancel">
        {{ t('common.cancel') }}
      </el-button>
      <el-button type="primary" @click="handleConfirm">
        {{ t('common.confirm') }}
      </el-button>
    </template>
  </el-dialog>
</template>

<script setup lang="ts">
import { ref, computed } from 'vue'
import { useI18n } from 'vue-i18n'
import type { ElTree } from 'element-plus'

interface TreeNode {
  label: string
  value: any
  children?: TreeNode[]
  [key: string]: any
}

interface TreeProps {
  label?: string
  children?: string
  disabled?: string
  isLeaf?: string
  [key: string]: any
}

const props = withDefaults(defineProps<{
  modelValue: any
  options: TreeNode[]
  treeData: TreeNode[]
  placeholder?: string
  clearable?: boolean
  multiple?: boolean
  disabled?: boolean
  filterable?: boolean
  remote?: boolean
  remoteMethod?: (query: string) => void
  title?: string
  width?: string
  top?: string
  modal?: boolean
  appendToBody?: boolean
  closeOnClickModal?: boolean
  closeOnPressEscape?: boolean
  showClose?: boolean
  destroyOnClose?: boolean
  nodeKey?: string
  defaultExpandedKeys?: any[]
  defaultCheckedKeys?: any[]
  treeProps?: TreeProps
}>(), {
  placeholder: '请选择',
  clearable: true,
  multiple: false,
  disabled: false,
  filterable: false,
  remote: false,
  title: '选择',
  width: '30%',
  top: '15vh',
  modal: true,
  appendToBody: false,
  closeOnClickModal: false,
  closeOnPressEscape: true,
  showClose: true,
  destroyOnClose: false,
  nodeKey: 'value',
  treeProps: () => ({
    label: 'label',
    children: 'children'
  })
})

const emit = defineEmits<{
  (e: 'update:modelValue', value: any): void
  (e: 'change', value: any): void
  (e: 'check', data: any, checked: any): void
  (e: 'node-click', data: any, node: any): void
}>()

const { t } = useI18n()
const dialogVisible = ref(false)
const treeRef = ref<InstanceType<typeof ElTree>>()

// 处理选择变化
const handleChange = (value: any) => {
  emit('update:modelValue', value)
  emit('change', value)
}

// 处理节点点击
const handleNodeClick = (data: any, node: any) => {
  if (!props.multiple) {
    emit('update:modelValue', data.value)
    emit('change', data.value)
    dialogVisible.value = false
  }
  emit('node-click', data, node)
}

// 处理节点选中
const handleCheck = (data: any, checked: any) => {
  if (props.multiple) {
    const checkedKeys = treeRef.value?.getCheckedKeys() || []
    emit('update:modelValue', checkedKeys)
    emit('change', checkedKeys)
  }
  emit('check', data, checked)
}

// 处理取消
const handleCancel = () => {
  dialogVisible.value = false
}

// 处理确认
const handleConfirm = () => {
  if (props.multiple) {
    const checkedKeys = treeRef.value?.getCheckedKeys() || []
    emit('update:modelValue', checkedKeys)
    emit('change', checkedKeys)
  }
  dialogVisible.value = false
}

// 打开对话框
const open = () => {
  dialogVisible.value = true
}

// 关闭对话框
const close = () => {
  dialogVisible.value = false
}

// 暴露方法给父组件
defineExpose({
  open,
  close,
  treeRef
})
</script>

<style scoped>
.tree-select-content {
  max-height: 400px;
  overflow-y: auto;
}
</style>