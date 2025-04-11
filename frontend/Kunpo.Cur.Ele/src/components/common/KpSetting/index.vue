<template>
  <div class="kp-setting">
    <el-button :type="type" :size="size" :icon="Setting" @click="handleClick">
      {{ t('common.setting') }}
    </el-button>

    <el-drawer v-model="visible" :title="t('common.setting')" :size="size" :direction="direction">
      <div class="setting-content">
        <el-scrollbar>
          <!-- 主题设置 -->
          <div class="setting-section">
            <div class="section-title">{{ t('setting.theme') }}</div>
            <div class="section-content">
              <el-form label-width="100px">
                <el-form-item :label="t('setting.themeMode')">
                  <el-radio-group v-model="themeMode">
                    <el-radio label="light">{{ t('setting.light') }}</el-radio>
                    <el-radio label="dark">{{ t('setting.dark') }}</el-radio>
                  </el-radio-group>
                </el-form-item>
                <el-form-item :label="t('setting.primaryColor')">
                  <el-color-picker v-model="primaryColor" />
                </el-form-item>
              </el-form>
            </div>
          </div>

          <!-- 导航设置 -->
          <div class="setting-section">
            <div class="section-title">{{ t('setting.navigation') }}</div>
            <div class="section-content">
              <el-form label-width="100px">
                <el-form-item :label="t('setting.navigationMode')">
                  <el-radio-group v-model="navigationMode">
                    <el-radio label="side">{{ t('setting.side') }}</el-radio>
                    <el-radio label="top">{{ t('setting.top') }}</el-radio>
                  </el-radio-group>
                </el-form-item>
                <el-form-item :label="t('setting.fixedHeader')">
                  <el-switch v-model="fixedHeader" />
                </el-form-item>
                <el-form-item :label="t('setting.fixedSidebar')">
                  <el-switch v-model="fixedSidebar" />
                </el-form-item>
              </el-form>
            </div>
          </div>

          <!-- 其他设置 -->
          <div class="setting-section">
            <div class="section-title">{{ t('setting.other') }}</div>
            <div class="section-content">
              <el-form label-width="100px">
                <el-form-item :label="t('setting.showBreadcrumb')">
                  <el-switch v-model="showBreadcrumb" />
                </el-form-item>
                <el-form-item :label="t('setting.showTags')">
                  <el-switch v-model="showTags" />
                </el-form-item>
                <el-form-item :label="t('setting.showFooter')">
                  <el-switch v-model="showFooter" />
                </el-form-item>
              </el-form>
            </div>
          </div>
        </el-scrollbar>
      </div>
    </el-drawer>
  </div>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import { useI18n } from 'vue-i18n'
import { Setting } from '@element-plus/icons-vue'

const props = withDefaults(defineProps<{
  type?: 'primary' | 'success' | 'warning' | 'danger' | 'info'
  size?: 'large' | 'default' | 'small'
}>(), {
  type: 'primary',
  size: 'default'
})

const emit = defineEmits<{
  (e: 'click'): void
  (e: 'change', settings: any): void
}>()

const { t } = useI18n()
const visible = ref(false)
const direction = ref('rtl')

// 主题设置
const themeMode = ref('light')
const primaryColor = ref('#409EFF')

// 导航设置
const navigationMode = ref('side')
const fixedHeader = ref(true)
const fixedSidebar = ref(true)

// 其他设置
const showBreadcrumb = ref(true)
const showTags = ref(true)
const showFooter = ref(true)

const handleClick = () => {
  visible.value = true
  emit('click')
}

// 监听设置变化
watch(
  [
    themeMode,
    primaryColor,
    navigationMode,
    fixedHeader,
    fixedSidebar,
    showBreadcrumb,
    showTags,
    showFooter
  ],
  () => {
    emit('change', {
      themeMode: themeMode.value,
      primaryColor: primaryColor.value,
      navigationMode: navigationMode.value,
      fixedHeader: fixedHeader.value,
      fixedSidebar: fixedSidebar.value,
      showBreadcrumb: showBreadcrumb.value,
      showTags: showTags.value,
      showFooter: showFooter.value
    })
  }
)
</script>

<style scoped>
.kp-setting {
  display: inline-block;
}

.setting-content {
  height: 100%;
}

.setting-section {
  padding: 16px;
  border-bottom: 1px solid #ebeef5;
}

.setting-section:last-child {
  border-bottom: none;
}

.section-title {
  font-size: 16px;
  font-weight: bold;
  margin-bottom: 16px;
  color: #303133;
}

.section-content {
  padding: 0 16px;
}
</style>