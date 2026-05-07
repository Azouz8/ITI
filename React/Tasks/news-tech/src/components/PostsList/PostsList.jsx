import styles from "./PostsList.module.css";
import Post from "./../PostCard/PostCard";
import { useSelector } from "react-redux";

const PostsList = () => {
  const posts = useSelector((state) => state.postsR.posts);
  const search = useSelector((state) => state.postsR.search);
  const filteredPosts = posts.filter((post) =>
    post.title.toLowerCase().includes(search.toLowerCase()),
  );
  return (
    <>
      <div className={styles.list}>
        {filteredPosts.map((post) => (
          <Post key={post.id} post={post} />
        ))}
      </div>
    </>
  );
};

export default PostsList;
