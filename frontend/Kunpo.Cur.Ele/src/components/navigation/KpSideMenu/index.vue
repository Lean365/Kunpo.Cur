<template>
  <el-menu :default-active="activeMenu" class="kp-side-menu" :collapse="isCollapse" :router="true" :unique-opened="true"
    :collapse-transition="false">
    <template v-for="item in menuItems" :key="item.path">
      <!-- 没有子菜单的情况 -->
      <el-menu-item v-if="!item.children" :index="item.path">
        <el-icon v-if="item.icon">
          <component :is="item.icon" />
        </el-icon>
        <template #title>{{ t(item.title) }}</template>
      </el-menu-item>

      <!-- 有子菜单的情况 -->
      <el-sub-menu v-else :index="item.path">
        <template #title>
          <el-icon v-if="item.icon">
            <component :is="item.icon" />
          </el-icon>
          <span>{{ t(item.title) }}</span>
        </template>
        <el-menu-item v-for="child in item.children" :key="child.path" :index="child.path">
          <el-icon v-if="child.icon">
            <component :is="child.icon" />
          </el-icon>
          <template #title>{{ t(child.title) }}</template>
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
  isCollapse?: boolean
}>()

const route = useRoute()
const { t } = useI18n()

const activeMenu = computed(() => route.path)
</script>

<style scoped>
.kp-side-menu {
  height: 100%;
  border-right: none;
}

.kp-side-menu:not(.el-menu--collapse) {
  width: 200px;
}

.el-menu-item,
.el-sub-menu__title {
  height: 50px;
  line-height: 50px;
}

.el-menu-item .el-icon,
.el-sub-menu__title .el-icon {
  margin-right: 8px;
  width: 24px;
  text-align: center;
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