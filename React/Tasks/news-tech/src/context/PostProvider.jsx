import { useState, useEffect } from "react";
import axios from "axios";
import { PostsContext } from "./PostsContext";
import toast from "react-hot-toast";

const PostProvider = ({ children }) => {
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
    axios.post("http://localhost:3000/posts", post).then((res) => {
      setPosts((prev) => [res.data, ...prev]);
      toast.success("Post Added Successfully! 🎉");
    });
  };

  const handleUpdatePost = (id, updatedData) => {
    setPosts((prev) =>
      prev.map((p) => (p.id === id ? { ...p, ...updatedData } : p)),
    );

    axios.patch(`http://localhost:3000/posts/${id}`, updatedData);
  };

  const filteredPosts =
    search.trim() === ""
      ? posts
      : posts.filter(
          (post) =>
            post.title.toLowerCase().includes(search.toLowerCase()) ||
            post.description.toLowerCase().includes(search.toLowerCase()),
        );

  return (
    <PostsContext.Provider
      value={{
        posts,
        filteredPosts,
        loading,
        error,
        search,
        setSearch,
        getPostData,
        handleUpdatePost,
      }}
    >
      {children}
    </PostsContext.Provider>
  );
};

export default PostProvider;
