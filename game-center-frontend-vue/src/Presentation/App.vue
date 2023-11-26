<template>
  <!--  <nav>-->
  <!--    <router-link to="/">Home</router-link>-->
  <!--    <router-link to="/about">About</router-link>-->
  <!--  </nav>-->
  <!--  <router-view />-->
  <TestPage></TestPage>
</template>

<style lang="scss">
@import "styles/tokens.css";
@import url("https://fonts.googleapis.com/css2?family=Roboto:wght@300;400;500&display=swap");

#app {
  font-family: "Roboto", sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
}

:root {
  @media (prefers-color-scheme: light) {
    --md-sys-color-surface-container-low: var(
      --md-sys-color-surface-container-low-light
    );
    --md-sys-color-shadow: var(--md-sys-color-shadow-light);
    --md-sys-color-primary: var(--md-sys-color-primary-light);
    --md-sys-color-surface-container-high: var(
      --md-sys-color-surface-container-high-light
    );
    --md-sys-color-primary-fixed: var(--md-sys-color-primary-fixed-light);
  }

  @media (prefers-color-scheme: dark) {
    --md-sys-color-surface-container-low: var(
      --md-sys-color-surface-container-low-dark
    );
    --md-sys-color-shadow: var(--md-sys-color-shadow-dark);
    --md-sys-color-primary: var(--md-sys-color-primary-dark);
    --md-sys-color-surface-container-high: var(
      --md-sys-color-surface-container-high-dark
    );
    --md-sys-color-primary-fixed: var(--md-sys-color-primary-fixed-dark);
  }
}
</style>
<script setup lang="ts">
import TestPage from "@presentation/components/pages/TestPage.vue";
</script>
