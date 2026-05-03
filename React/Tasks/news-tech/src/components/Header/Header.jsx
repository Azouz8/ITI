import styles from "./Header.module.css";

const Header = ({ search, setSearch }) => {
  return (
    <nav className={styles.nav}>
      <div className={styles.container}>
        <h1 className={styles.title}>News Feed</h1>

        <div className={styles.searchBox}>
          <input
            type="text"
            placeholder="Search posts..."
            value={search}
            onChange={(e) => setSearch(e.target.value)}
            className={styles.searchInput}
          />
        </div>
      </div>
    </nav>
  );
};

export default Header;
