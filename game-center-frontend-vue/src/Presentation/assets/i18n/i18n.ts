import { createI18n } from "vue-i18n";
import enFillWord from "@presentation/assets/i18n/en/enFillWord";

const messages = {
  en: {
    ...enFillWord,
  },
  ru: {},
};

export default createI18n({
  locale: "en",
  fallbackLocale: "ru",
  messages,
});
