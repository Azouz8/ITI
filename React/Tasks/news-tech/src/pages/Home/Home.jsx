import Header from "../../components/Header/Header";
import Sidebar from "../../components/Sidebar/Sidebar";
import Carousel from "../../components/Carousel/Carousel";
import Footer from "../../components/Footer/Footer";
import styles from "./Home.module.css";
import PostsList from "../../components/PostsList/PostsList";
import { useDispatch, useSelector } from "react-redux";
import { useEffect } from "react";
import { fetchPostsAsync } from "../../redux/slices/postsSlice";

const Home = () => {
  const dispatch = useDispatch();
  let loading = useSelector((state) => state.postsR.loading);
  let error = useSelector((state) => state.postsR.error);
  let lang = useSelector((state) => state.langR.language);
  const posts = useSelector((state) => state.postsR.posts);
  useEffect(() => {
    if (posts.length === 0) {
      dispatch(fetchPostsAsync());
    }
  }, [dispatch]);
  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error}</p>;
  return (
    <>
      <div dir={lang === "EN" ? "ltr" : "rtl"}>
        <div className={styles.layout}>
          <Header />
          <div className={styles.content}>
            <div className={styles.row}>
              <div className={styles.sidebarCol}>
                <Sidebar />
              </div>
              <div className={styles.mainCol}>
                <Carousel />
                <PostsList />
              </div>
            </div>
          </div>
          <Footer />
        </div>
      </div>
    </>
  );
};

export default Home;
