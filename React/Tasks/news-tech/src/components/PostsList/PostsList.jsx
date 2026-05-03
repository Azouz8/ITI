import axios from "axios";
import styles from "./PostsList.module.css";
import Post from "./../PostCard/PostCard";

const PostsList = ({ posts, setPosts }) => {
  const handleUpdatePost = (id, updatedData) => {
    setPosts((prevPosts) =>
      prevPosts.map((post) =>
        post.id === id ? { ...post, ...updatedData } : post,
      ),
    );

    axios
      .patch(`http://localhost:3000/posts/${id}`, updatedData)
      .catch((err) => console.error("Failed to update post", err));
  };

  return (
    <>
      <div className={styles.list}>
        {posts.map((post) => (
          <Post key={post.id} post={post} onUpdate={handleUpdatePost} />
        ))}
      </div>
    </>
  );
};

export default PostsList;
