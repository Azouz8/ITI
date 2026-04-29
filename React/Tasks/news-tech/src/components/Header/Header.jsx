import { Component } from "react";
import styles from "./Header.module.css";

class Header extends Component {
  render() {
    return (
      <nav className={styles.nav}>
        <div className={styles.container}>
          <h1 className={styles.title}>NewsTech</h1>
        </div>
      </nav>
    );
  }
}

// const Header = () => {
//   return (
//     <nav className="header-nav">
//       <div className="header-container">
//         <h1 className="header-title">Header</h1>
//       </div>
//     </nav>
//   );
// };

export default Header;
