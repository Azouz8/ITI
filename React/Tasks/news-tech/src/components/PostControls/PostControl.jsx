import { useState } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faArrowUp } from "@fortawesome/free-solid-svg-icons";
import { faArrowDown } from "@fortawesome/free-solid-svg-icons";
import { faMessage } from "@fortawesome/free-regular-svg-icons";
import { faBookmark } from "@fortawesome/free-regular-svg-icons";
import { faShareFromSquare } from "@fortawesome/free-regular-svg-icons";
import styles from "./PostControl.module.css";
import { useDispatch } from "react-redux";
import { updatePostAsync } from "./../../redux/slices/postsSlice";

const PostControl = ({
  id,
  likeCount,
  dislikeCount,
  commentCount,
  shareCount,
}) => {
  const [vote, setVote] = useState(null);
  const dispatch = useDispatch();

  const clickUpIcon = (e) => {
    e.stopPropagation();
    if (vote === "up") {
      setVote(null);
      dispatch(updatePostAsync({ id, updates: { likeCount: likeCount - 1 } }));
    } else {
      setVote("up");
      dispatch(
        updatePostAsync({
          id,
          updates: {
            likeCount: likeCount + 1,
            dislikeCount: vote === "down" ? dislikeCount - 1 : dislikeCount,
          },
        }),
      );
    }
  };

  const clickDownIcon = (e) => {
    e.stopPropagation();
    if (vote === "down") {
      setVote(null);
      dispatch(
        updatePostAsync({ id, updates: { dislikeCount: dislikeCount - 1 } }),
      );
    } else {
      setVote("down");
      dispatch(
        updatePostAsync({
          id,
          updates: {
            dislikeCount: dislikeCount + 1,
            likeCount: vote === "up" ? likeCount - 1 : likeCount,
          },
        }),
      );
    }
  };
  return (
    <>
      <div className={styles.controls}>
        <div className={styles.control} onClick={clickUpIcon}>
          <FontAwesomeIcon
            className={vote === "up" ? styles.activeIcon : styles.icon}
            icon={faArrowUp}
          />
          <p className={vote === "up" ? styles.activeNumber : styles.number}>
            {likeCount}
          </p>
        </div>
        <div className={styles.control} onClick={clickDownIcon}>
          <FontAwesomeIcon
            className={vote === "down" ? styles.activeIcon : styles.icon}
            icon={faArrowDown}
          />
        </div>
        <div className={styles.control}>
          <FontAwesomeIcon className={styles.icon} icon={faMessage} />
          <p className={styles.number}>{commentCount}</p>
        </div>
        <div className={styles.control}>
          <FontAwesomeIcon className={styles.icon} icon={faBookmark} />
        </div>
        <div className={styles.control}>
          <FontAwesomeIcon className={styles.icon} icon={faShareFromSquare} />
          <p className={styles.number}>{shareCount}</p>
        </div>
      </div>
    </>
  );
};

export default PostControl;
