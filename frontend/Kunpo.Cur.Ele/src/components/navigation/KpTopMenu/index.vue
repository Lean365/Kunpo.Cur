<template>
  <el-menu :default-active="activeMenu" class="kp-top-menu" mode="horizontal" :router="true">
    <template v-for="item in menuItems" :key="item.path">
      <!-- 没有子菜单的情况 -->
      <el-menu-item v-if="!item.children" :index="item.path">
        <el-icon v-if="item.icon">
          <component :is="item.icon" />
        </el-icon>
        {{ t(item.title) }}
      </el-menu-item>

      <!-- 有子菜单的情况 -->
      <el-sub-menu v-else :index="item.path">
        <template #title>
          <el-icon v-if="item.icon">
            <component :is="item.icon" />
          </el-icon>
          {{ t(item.title) }}
        </template>
        <el-menu-item v-for="child in item.children" :key="child.path" :index="child.path">
          <el-icon v-if="child.icon">
            <component :is="child.icon" />
          </el-icon>
          {{ t(child.title) }}
        </el-menu-item>
      </el-sub-menu>
    </template>
  </el-menu>
</template>

<script setup lang="ts">
import { computed } from 'vue'
import { useRoute } from 'vue-router/dist/vue-router'
import { useI18n } from 'vue-i18n'
import type { MenuItem } from '@/types/menu'

defineProps<{
  menuItems: MenuItem[]
}>()

const route = useRoute()
const { t } = useI18n()

const activeMenu = computed(() => route.path)
</script>

<style scoped>
.kp-top-menu {
  border-bottom: none;
}

.el-menu-item,
.el-sub-menu__title {
  height: 60px;
  line-height: 60px;
}

.el-menu-item .el-icon,
.el-sub-menu__title .el-icon {
  margin-right: 4px;
  vertical-align: middle;
}

/* 菜单项悬停效果 */
.el-menu-item:hover,
.el-sub-menu__title:hover {
  background-color: var(--el-menu-hover-bg-color);
}

/* 选中菜单项样式 */
.el-menu-item.is-active {
  background-color: var(--el-menu-active-bg-color);
}
</style>