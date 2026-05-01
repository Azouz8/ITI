import { Component } from "react";
import axios from "axios";
import Header from "../../components/Header/Header";
import Sidebar from "../../components/Sidebar/Sidebar";
import Carousel from "../../components/Carousel/Carousel";
import Footer from "../../components/Footer/Footer";
import styles from "./Home.module.css";
import PostsList from "../../components/PostsList/PostsList";

class Home extends Component {
  constructor(props) {
    super(props);
    this.state = {
      newPost: null,
    };
  }

  getPostData = (post) => {
    axios
      .post("http://localhost:3000/posts", post)
      .then((res) => {
        this.setState({ newPost: res.data });
      })
      .catch((err) => console.error("Error adding post:", err));
  };

  render() {
    return (
      <div className={styles.layout}>
        <Header />
        <div className={styles.content}>
          <div className={styles.row}>
            <div className={styles["sidebar-col"]}>
              <Sidebar getPostData={this.getPostData} />
            </div>
            <div className={styles["main-col"]}>
              <Carousel />
              <PostsList newPost={this.state.newPost} />
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
