import { createI18n } from "vue-i18n";
import enFillWord from "@presentation/assets/i18n/en/enFillWord";
import ruFillWord from "@presentation/assets/i18n/ru/ruFillWord";

const messages = {
  en: {
    ...enFillWord,
  },
  ru: {
    ...ruFillWord,
  },
};

export default createI18n({
  locale: "ru",
  fallbackLocale: "en",
  messages,
});
