import { useContext } from "react";
import Header from "../../components/Header/Header";
import Sidebar from "../../components/Sidebar/Sidebar";
import Carousel from "../../components/Carousel/Carousel";
import Footer from "../../components/Footer/Footer";
import styles from "./Home.module.css";
import PostsList from "../../components/PostsList/PostsList";
import { PostsContext } from "../../context/PostsContext";

const Home = () => {
  const { loading, error } = useContext(PostsContext);

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error}</p>;
  
  return (
    <>

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
    </>
  );
};

export default Home;
