import styles from "./Footer.module.css";
import { useTranslation } from "react-i18next";

const Footer = () => {
  let { t, i18n } = useTranslation("footer");
  return (
    <footer className={styles.footer}>
      <div className={styles.container}>
        <h5 className={styles.title}>{t("NewsTech")}</h5>
        <p className={styles.text}>{t("description")}</p>
      </div>
    </footer>
  );
};

export default Footer;
