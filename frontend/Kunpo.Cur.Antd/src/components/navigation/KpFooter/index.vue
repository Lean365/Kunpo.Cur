<template>
  <a-layout-footer class="kp-footer">
    <div class="kp-footer-content">
      <div class="kp-footer-links">
        <a v-for="link in links" :key="link.key" :href="link.href" target="_blank">
          {{ link.title }}
        </a>
      </div>
      <div class="kp-footer-copyright">
        Copyright © {{ year }} {{ title }} {{ t('footer.copyright') }}
      </div>
    </div>
  </a-layout-footer>
</template>

<script lang="ts" setup>
import { ref, computed } from 'vue'
import { useI18n } from 'vue-i18n'

const { t } = useI18n()

const title = ref('Kunpo.Cur')
const year = computed(() => new Date().getFullYear())

const links = [
  {
    key: 'github',
    title: 'GitHub',
    href: 'https://github.com/your-org/your-repo'
  },
  {
    key: 'docs',
    title: t('footer.docs'),
    href: 'https://docs.example.com'
  },
  {
    key: 'help',
    title: t('footer.help'),
    href: 'https://help.example.com'
  },
  {
    key: 'privacy',
    title: t('footer.privacy'),
    href: 'https://privacy.example.com'
  },
  {
    key: 'terms',
    title: t('footer.terms'),
    href: 'https://terms.example.com'
  }
]
</script>

<style lang="less" scoped>
.kp-footer {
  padding: 16px 24px;
  text-align: center;
  background: #fff;

  &-content {
    max-width: 1200px;
    margin: 0 auto;
  }

  &-links {
    margin-bottom: 8px;

    a {
      color: rgba(0, 0, 0, 0.45);
      transition: all 0.3s;

      &:not(:last-child) {
        margin-right: 40px;
      }

      &:hover {
        color: rgba(0, 0, 0, 0.85);
      }
    }
  }

  &-copyright {
    color: rgba(0, 0, 0, 0.45);
    font-size: 14px;
  }
}
</style>