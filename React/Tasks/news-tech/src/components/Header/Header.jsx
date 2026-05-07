import { useNavigate } from "react-router";
import styles from "./Header.module.css";
import { useTranslation } from "react-i18next";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faEarth } from "@fortawesome/free-solid-svg-icons";
import { faMoon } from "@fortawesome/free-solid-svg-icons";
import { faSun } from "@fortawesome/free-solid-svg-icons";
import { useDispatch, useSelector } from "react-redux";
import { changeLang } from "../../redux/slices/langSlice";
import { changeTheme } from "../../redux/slices/themeSlice";
import { setSearch } from "../../redux/slices/postsSlice";

const Header = () => {
  const navigateTo = useNavigate();
  const logoutClick = () => {
    localStorage.removeItem("user");
    navigateTo("/login", { replace: true });
  };

  let lang = useSelector((state) => state.langR.language);
  let theme = useSelector((state) => state.themeR.isDark);

  let dispatch = useDispatch();

  const search = useSelector((state) => state.postsR.search);
  let { t, i18n } = useTranslation("header");
  return (
    <nav className={styles.nav}>
      <div className={styles.container}>
        <h1 className={styles.title}>{t("NewsTech")}</h1>
        <div className={styles.searchBox}>
          <input
            type="text"
            placeholder={t("Search posts...")}
            value={search}
            onChange={(e) => dispatch(setSearch(e.target.value))}
            className={styles.searchInput}
          />
        </div>
        {theme ? (
          <div
            className={styles.sunIcon}
            onClick={() => dispatch(changeTheme())}
          >
            <FontAwesomeIcon icon={faSun} />
          </div>
        ) : (
          <div
            className={styles.moonIcon}
            onClick={() => dispatch(changeTheme())}
          >
            <FontAwesomeIcon icon={faMoon} />
          </div>
        )}
        <div
          className={styles.langIcon}
          onClick={() => {
            if (i18n.language === "en") {
              i18n.changeLanguage("ar");
              dispatch(changeLang("ع"));
            } else {
              i18n.changeLanguage("en");
              dispatch(changeLang("EN"));
            }
          }}
        >
          <FontAwesomeIcon icon={faEarth} />
          <span>{lang}</span>
        </div>
        <button className="btn btn-outline-danger" onClick={logoutClick}>
          {t("Logout")}
        </button>
      </div>
    </nav>
  );
};

export default Header;
