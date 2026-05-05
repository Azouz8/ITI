import styles from "./PostCard.module.css";
import PostControl from "./../PostControls/PostControl";
import { useNavigate } from "react-router";

const Post = ({ post }) => {
  const navigateTo = useNavigate();
  const handleOnClick = () => {
    navigateTo(`/post/${post.id}`);
  };

  return (
    <>
      <div className={styles.card} onClick={handleOnClick}>
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
    </>
  );
};

export default Post;
