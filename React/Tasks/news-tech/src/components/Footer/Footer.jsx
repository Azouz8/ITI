import { Component } from "react";
import styles from "./Footer.module.css";

class Footer extends Component {
  render() {
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
  }
}

// const Footer = () => {
//   return (
//     <footer className="footer">
//       <div className="footer-container">
//         <h5 className="footer-title">Task Manager</h5>
//         <p className="footer-text">
//           Manage your daily tasks efficiently and stay productive.
//         </p>
//       </div>
//     </footer>
//   );
// };

export default Footer;
