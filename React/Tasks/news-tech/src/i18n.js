import i18n from "i18next";
import { initReactI18next } from "react-i18next";
import headerAR from "./localization/ar/header.json"
import headerEN from "./localization/en/header.json"
import footerEN from "./localization/en/footer.json"
import sidebarAR from "./localization/ar/sidebarForm.json"
import sidebarEN from "./localization/en/sidebarForm.json"
import footerAR from "./localization/ar/footer.json"

i18n.use(initReactI18next).init({
    resources: {
        en: {
            header: headerEN,
            sidebar: sidebarEN,
            footer: footerEN
        },
        ar: {
            header: headerAR,
            sidebar: sidebarAR,
            footer: footerAR
        },
    },
    lng: "en",
    fallbackLng: "en",
    ns: ['header', 'sidebar', 'footer'],
    defaultNs: 'header',

    interpolation: {
        escapeValue: false,
    },
})