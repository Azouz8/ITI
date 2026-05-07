import { useNavigate, useParams } from "react-router";
import PostControl from "./../../components/PostControls/PostControl";
import styles from "./PostPage.module.css";
import { useSelector } from "react-redux";

const PostPage = () => {
  const { id } = useParams();

  const posts = useSelector((state) => state.postsR.posts ?? []);

  const post = posts.find((p) => p.id === id);

  const navigateTo = useNavigate();

  if (!post) return <p>Loading......</p>;
  return (
    <>
      <div className={styles.container}>
        <button className={styles.backButton} onClick={() => navigateTo("/")}>
          ← Back to Home
        </button>
        <div className={styles.card}>
          <img className={styles.img} src={post.imgUrl} alt="Card image cap" />
          <div className={styles.body}>
            <h5 className={styles.title}>{post.title}</h5>
            <p className={styles.text}>{post.description}</p>
          </div>
          <div className={styles.controls}>
            <PostControl
              id={post.id}
              likeCount={post.likeCount}
              dislikeCount={post.dislikeCount}
              commentCount={post.commentCount}
              shareCount={post.shareCount}
            />
          </div>
        </div>
      </div>
    </>
  );
};

export default PostPage;
