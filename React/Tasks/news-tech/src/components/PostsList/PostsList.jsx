import styles from "./PostsList.module.css";
import Post from "./../PostCard/PostCard";
import { useContext } from "react";
import { PostsContext } from "../../context/PostsContext";

const PostsList = () => {
  const { filteredPosts } = useContext(PostsContext);

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
