import { useState } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faArrowUp } from "@fortawesome/free-solid-svg-icons";
import { faArrowDown } from "@fortawesome/free-solid-svg-icons";
import { faMessage } from "@fortawesome/free-regular-svg-icons";
import { faBookmark } from "@fortawesome/free-regular-svg-icons";
import { faShareFromSquare } from "@fortawesome/free-regular-svg-icons";
import styles from "./PostControl.module.css";

const PostControl = ({
  id,
  likeCount,
  dislikeCount,
  commentCount,
  shareCount,
  onUpdate,
}) => {
  const [vote, setVote] = useState(null);

  const clickUpIcon = () => {
    if (vote === "up") {
      setVote(null);
      if (onUpdate) {
        onUpdate(id, {
          likeCount: likeCount - 1,
        });
      }
    } else {
      const newLikeCount = likeCount + 1;
      const newDislikeCount = vote === "down" ? dislikeCount - 1 : dislikeCount;
      setVote("up");

      onUpdate(id, {
        likeCount: newLikeCount,
        dislikeCount: newDislikeCount,
      });
    }
  };

  const clickDownIcon = () => {
    if (vote === "down") {
      setVote(null);
      if (onUpdate) {
        onUpdate(id, {
          dislikeCount: dislikeCount - 1,
        });
      }
    } else {
      const newDislikeCount = dislikeCount + 1;
      const newLikeCount = vote === "up" ? likeCount - 1 : likeCount;
      setVote("down");

      onUpdate(id, {
        likeCount: newLikeCount,
        dislikeCount: newDislikeCount,
      });
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
