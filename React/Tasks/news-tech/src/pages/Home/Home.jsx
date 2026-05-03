import { useEffect, useState } from "react";
import axios from "axios";
import Header from "../../components/Header/Header";
import Sidebar from "../../components/Sidebar/Sidebar";
import Carousel from "../../components/Carousel/Carousel";
import Footer from "../../components/Footer/Footer";
import styles from "./Home.module.css";
import PostsList from "../../components/PostsList/PostsList";

const Home = () => {
  const [posts, setPosts] = useState([]);
  const [search, setSearch] = useState("");
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    axios
      .get("http://localhost:3000/posts")
      .then((res) => {
        setPosts(res.data);
        setLoading(false);
      })
      .catch((err) => {
        setError(err.message);
        setLoading(false);
      });
  }, []);

  const getPostData = (post) => {
    axios
      .post("http://localhost:3000/posts", post)
      .then((res) => {
        setPosts((prev) => [res.data, ...prev]);
      })
      .catch((err) => console.error(err));
  };

  const filteredPosts =
    search.trim() === ""
      ? posts
      : posts.filter(
          (post) =>
            post.title.toLowerCase().includes(search.toLowerCase()) ||
            post.description.toLowerCase().includes(search.toLowerCase()),
        );

  if (loading) return <p>Loading...</p>;
  if (error) return <p>Error: {error}</p>;
  return (
    <div className={styles.layout}>
      <Header search={search} setSearch={setSearch} />

      <div className={styles.content}>
        <div className={styles.row}>
          <div className={styles["sidebar-col"]}>
            <Sidebar getPostData={getPostData} />
          </div>

          <div className={styles["main-col"]}>
            <Carousel />
            <PostsList posts={filteredPosts} setPosts={setPosts} />
          </div>
        </div>
      </div>

      <Footer />
    </div>
  );
};

export default Home;
