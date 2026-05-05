import { useNavigate } from "react-router";
import styles from "./Header.module.css";
import { useContext } from "react";
import { PostsContext } from "../../context/PostsContext";

const Header = () => {
  const navigateTo = useNavigate();

  const logoutClick = () => {
    localStorage.removeItem("user");
    navigateTo("/login", { replace: true });
  };

  const { search, setSearch } = useContext(PostsContext);

  return (
    <nav className={styles.nav}>
      <div className={styles.container}>
        <h1 className={styles.title}>NewsTech</h1>
        <div className={styles.searchBox}>
          <input
            type="text"
            placeholder="Search posts..."
            value={search}
            onChange={(e) => setSearch(e.target.value)}
            className={styles.searchInput}
          />
        </div>
        <button className="btn btn-outline-danger" onClick={logoutClick}>
          Logout
        </button>
      </div>
    </nav>
  );
};

export default Header;
