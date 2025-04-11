<template>
  <div class="kp-tabs">
    <el-tabs v-model="activeTab" type="card" closable @tab-remove="removeTab" @tab-click="handleTabClick">
      <el-tab-pane v-for="tab in tabs" :key="tab.path" :label="tab.title" :name="tab.path" :closable="tab.path !== '/'"
        @close="removeTab(tab.path)">
        <template #label>
          <el-icon v-if="tab.icon" class="tab-icon">
            <component :is="tab.icon" />
          </el-icon>
          {{ t(tab.title) }}
        </template>
      </el-tab-pane>
    </el-tabs>
  </div>
</template>

<script setup lang="ts">
import { ref, watch } from 'vue'
import { useRoute, useRouter } from 'vue-router/dist/vue-router'
import { useI18n } from 'vue-i18n'
import type { MenuItem } from '@/types/menu'
import type { TabPaneName } from 'element-plus'

interface TabItem extends MenuItem {
  path: string
}

const props = defineProps<{
  tabs: TabItem[]
}>()

const emit = defineEmits<{
  (e: 'update:tabs', tabs: TabItem[]): void
  (e: 'tab-click', tab: TabItem): void
}>()

const route = useRoute()
const router = useRouter()
const { t } = useI18n()

const activeTab = ref(route.path)

// 监听路由变化，更新激活的标签
watch(
  () => route.path,
  (newPath) => {
    activeTab.value = newPath
  }
)

// 移除标签
const removeTab = (name: TabPaneName) => {
  const newTabs = props.tabs.filter(tab => tab.path !== name)
  emit('update:tabs', newTabs)

  // 如果关闭的是当前激活的标签，则切换到最后一个标签
  if (name === activeTab.value && newTabs.length > 0) {
    const lastTab = newTabs[newTabs.length - 1]
    router.push(lastTab.path)
  }
}

// 点击标签
const handleTabClick = (tab: any) => {
  const targetTab = props.tabs.find(t => t.path === tab.props.name)
  if (targetTab) {
    emit('tab-click', targetTab)
  }
}
</script>

<style scoped>
.kp-tabs {
  background-color: #fff;
  padding: 6px 6px 0;
  border-bottom: 1px solid #dcdfe6;
}

.tab-icon {
  margin-right: 4px;
  vertical-align: middle;
}

:deep(.el-tabs__nav-wrap::after) {
  height: 1px;
}

:deep(.el-tabs__item) {
  height: 40px;
  line-height: 40px;
  padding: 0 20px;
}

:deep(.el-tabs__item.is-active) {
  background-color: var(--el-color-primary-light-9);
  border-bottom-color: var(--el-color-primary);
  color: var(--el-color-primary);
}
</style>