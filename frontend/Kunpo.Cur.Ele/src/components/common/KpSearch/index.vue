<template>
  <div class="kp-search">
    <el-popover v-model:visible="visible" placement="bottom" :width="400" trigger="click">
      <template #reference>
        <el-button :icon="Search" circle />
      </template>

      <div class="search-content">
        <el-input v-model="keyword" :placeholder="t('common.searchPlaceholder')" :prefix-icon="Search" clearable
          @input="handleInput" />

        <div class="search-results" v-if="keyword">
          <div v-for="(item, index) in filteredResults" :key="index" class="search-item"
            :class="{ active: index === activeIndex }" @click="handleSelect(item)" @mouseenter="activeIndex = index">
            <el-icon>
              <component :is="item.icon" />
            </el-icon>
            <span class="item-title">{{ item.title }}</span>
            <span class="item-path">{{ item.path }}</span>
          </div>
        </div>

        <div class="search-tips" v-else>
          <div class="tip-item">
            <el-icon>
              <Key />
            </el-icon>
            <span>{{ t('common.searchKeyboardTip') }}</span>
          </div>
          <div class="tip-item">
            <el-icon>
              <ArrowUp />
            </el-icon>
            <span>{{ t('common.searchArrowTip') }}</span>
          </div>
        </div>
      </div>
    </el-popover>
  </div>
</template>

<script setup lang="ts">
import { ref, computed, onMounted, onUnmounted } from 'vue'
import { useI18n } from 'vue-i18n'
import { Search, Key, ArrowUp } from '@element-plus/icons-vue'

interface SearchItem {
  title: string
  path: string
  icon: string
  keywords?: string[]
}

const props = withDefaults(defineProps<{
  items?: SearchItem[]
}>(), {
  items: () => []
})

const emit = defineEmits<{
  (e: 'select', item: SearchItem): void
}>()

const { t } = useI18n()
const visible = ref(false)
const keyword = ref('')
const activeIndex = ref(0)

// 过滤搜索结果
const filteredResults = computed(() => {
  if (!keyword.value) return []

  return props.items.filter(item => {
    const searchText = keyword.value.toLowerCase()
    return (
      item.title.toLowerCase().includes(searchText) ||
      item.path.toLowerCase().includes(searchText) ||
      item.keywords?.some(keyword => keyword.toLowerCase().includes(searchText))
    )
  })
})

// 处理输入
const handleInput = () => {
  activeIndex.value = 0
}

// 处理选择
const handleSelect = (item: SearchItem) => {
  emit('select', item)
  visible.value = false
  keyword.value = ''
}

// 键盘事件处理
const handleKeydown = (e: KeyboardEvent) => {
  if (!visible.value) return

  switch (e.key) {
    case 'ArrowDown':
      e.preventDefault()
      if (activeIndex.value < filteredResults.value.length - 1) {
        activeIndex.value++
      }
      break
    case 'ArrowUp':
      e.preventDefault()
      if (activeIndex.value > 0) {
        activeIndex.value--
      }
      break
    case 'Enter':
      e.preventDefault()
      if (filteredResults.value[activeIndex.value]) {
        handleSelect(filteredResults.value[activeIndex.value])
      }
      break
    case 'Escape':
      visible.value = false
      keyword.value = ''
      break
  }
}

// 监听键盘事件
onMounted(() => {
  window.addEventListener('keydown', handleKeydown)
})

onUnmounted(() => {
  window.removeEventListener('keydown', handleKeydown)
})
</script>

<style scoped>
.kp-search {
  display: inline-block;
}

.search-content {
  padding: 8px;
}

.search-results {
  margin-top: 8px;
  max-height: 300px;
  overflow-y: auto;
}

.search-item {
  display: flex;
  align-items: center;
  padding: 8px;
  cursor: pointer;
  border-radius: 4px;
  transition: background-color 0.2s;
}

.search-item:hover,
.search-item.active {
  background-color: var(--el-color-primary-light-9);
}

.search-item .el-icon {
  margin-right: 8px;
  font-size: 16px;
  color: var(--el-text-color-secondary);
}

.item-title {
  flex: 1;
  font-weight: 500;
}

.item-path {
  color: var(--el-text-color-secondary);
  font-size: 12px;
  margin-left: 8px;
}

.search-tips {
  margin-top: 16px;
  color: var(--el-text-color-secondary);
}

.tip-item {
  display: flex;
  align-items: center;
  margin-bottom: 8px;
}

.tip-item .el-icon {
  margin-right: 8px;
}
</style>