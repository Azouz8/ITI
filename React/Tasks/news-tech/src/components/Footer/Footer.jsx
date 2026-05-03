import styles from "./Footer.module.css";

const Footer = () => {
  return (
    <footer className={styles.footer}>
      <div className={styles.container}>
        <h5 className={styles.title}>NewsTech</h5>
        <p className={styles.text}>
          Open source news aggregator focused on high-performance runtimes and
          clean code.
        </p>
      </div>
    </footer>
  );
};

export default Footer;
