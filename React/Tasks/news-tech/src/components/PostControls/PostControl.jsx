import { Component } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faArrowUp } from "@fortawesome/free-solid-svg-icons";
import { faArrowDown } from "@fortawesome/free-solid-svg-icons";
import { faMessage } from "@fortawesome/free-regular-svg-icons";
import { faBookmark } from "@fortawesome/free-regular-svg-icons";
import { faShareFromSquare } from "@fortawesome/free-regular-svg-icons";
import styles from "./PostControl.module.css";

class PostControl extends Component {
  render() {
    return (
      <>
        <div className={styles.controls}>
          <div className={styles.control}>
            <FontAwesomeIcon className={styles.icon} icon={faArrowUp} />
            <p>110</p>
          </div>
          <div className={styles.control}>
            <FontAwesomeIcon className={styles.icon} icon={faArrowDown} />
          </div>
          <div className={styles.control}>
            <FontAwesomeIcon className={styles.icon} icon={faMessage} />
            <p>35</p>
          </div>
          <div className={styles.control}>
            <FontAwesomeIcon className={styles.icon} icon={faBookmark} />
          </div>
          <div className={styles.control}>
            <FontAwesomeIcon className={styles.icon} icon={faShareFromSquare} />
          </div>
        </div>
      </>
    );
  }
}

export default PostControl;
