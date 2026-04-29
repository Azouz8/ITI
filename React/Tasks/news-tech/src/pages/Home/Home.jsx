import { Component } from "react";
import Header from "../../components/Header/Header";
import Sidebar from "../../components/Sidebar/Sidebar";
import Carousel from "../../components/Carousel/Carousel";
import Footer from "../../components/Footer/Footer";
import styles from "./Home.module.css";
import PostsList from "../../components/PostsList/PostsList";

class Home extends Component {
  render() {
    return (
      <div className={styles.layout}>
        <Header />
        <div className={styles.content}>
          <div className={styles.row}>
            <div className={styles["sidebar-col"]}>
              <Sidebar />
            </div>
            <div className={styles["main-col"]}>
              <Carousel />
              <PostsList />
            </div>
          </div>
        </div>
        <Footer />
      </div>
    );
  }
}

// function Home() {
//   return (
//     <div className="home-layout">
//       <Header />
//       <div className="home-content">
//         <div className="home-row">
//           <div className="home-sidebar-col">
//             <Sidebar />
//           </div>
//           <div className="home-main-col">
//             <CardList />
//           </div>
//         </div>
//       </div>
//       <Footer />
//     </div>
//   );
// }
export default Home;
