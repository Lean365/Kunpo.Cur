<template>
  <el-footer class="kp-footer">
    <div class="footer-content">
      <slot>
        <span>{{ t('footer.copyright') }}</span>
      </slot>
    </div>
  </el-footer>
</template>

<script setup lang="ts">
import { useI18n } from 'vue-i18n'

const { t } = useI18n()
</script>

<style scoped>
.kp-footer {
  background-color: #fff;
  border-top: 1px solid #dcdfe6;
  padding: 20px;
  text-align: center;
  color: #909399;
}

.footer-content {
  max-width: 1200px;
  margin: 0 auto;
}
</style>