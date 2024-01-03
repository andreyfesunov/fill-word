import { createApp } from "vue";
import App from "./App.vue";
import router from "./router";
import store from "@presentation/store";
import i18n from "@presentation/assets/i18n/i18n";

createApp(App).use(router).use(store).use(i18n).mount("#app");