import { Component } from "react";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faArrowUp } from "@fortawesome/free-solid-svg-icons";
import { faArrowDown } from "@fortawesome/free-solid-svg-icons";
import { faMessage } from "@fortawesome/free-regular-svg-icons";
import { faBookmark } from "@fortawesome/free-regular-svg-icons";
import { faShareFromSquare } from "@fortawesome/free-regular-svg-icons";
import styles from "./PostControl.module.css";

class PostControl extends Component {
  constructor(props) {
    super(props);
    this.state = {
      upArrowClicked: false,
      downArrowClicked: false,
    };
  }
  clickUpIcon = () => {
    if (this.state.upArrowClicked) {
      this.setState({ upArrowClicked: false });
      if (this.props.onUpdate) {
        this.props.onUpdate(this.props.id, {
          likeCount: this.props.likeCount - 1,
        });
      }
    } else {
      const newLikeCount = this.props.likeCount + 1;
      let newDislikeCount = this.props.dislikeCount;
      const stateUpdates = { upArrowClicked: true };

      if (this.state.downArrowClicked) {
        newDislikeCount -= 1;
        stateUpdates.downArrowClicked = false;
      }
      this.setState(stateUpdates);
      if (this.props.onUpdate) {
        this.props.onUpdate(this.props.id, {
          likeCount: newLikeCount,
          dislikeCount: newDislikeCount,
        });
      }
    }
  };

  clickDownIcon = () => {
    if (this.state.downArrowClicked) {
      this.setState({ downArrowClicked: false });
      if (this.props.onUpdate) {
        this.props.onUpdate(this.props.id, {
          dislikeCount: this.props.dislikeCount - 1,
        });
      }
    } else {
      let newLikeCount = this.props.likeCount;
      const newDislikeCount = this.props.dislikeCount + 1;
      const stateUpdates = { downArrowClicked: true };

      if (this.state.upArrowClicked) {
        newLikeCount -= 1;
        stateUpdates.upArrowClicked = false;
      }
      this.setState(stateUpdates);
      if (this.props.onUpdate) {
        this.props.onUpdate(this.props.id, {
          likeCount: newLikeCount,
          dislikeCount: newDislikeCount,
        });
      }
    }
  };
  render() {
    const { likeCount, dislikeCount, commentCount, shareCount } = this.props;
    return (
      <>
        <div className={styles.controls}>
          <div className={styles.control} onClick={this.clickUpIcon}>
            <FontAwesomeIcon
              className={
                this.state.upArrowClicked ? styles.activeIcon : styles.icon
              }
              icon={faArrowUp}
            />
            <p
              className={
                this.state.upArrowClicked ? styles.activeNumber : styles.number
              }
            >
              {likeCount}
            </p>
          </div>
          <div className={styles.control} onClick={this.clickDownIcon}>
            <FontAwesomeIcon
              className={
                this.state.downArrowClicked ? styles.activeIcon : styles.icon
              }
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
  }
}

export default PostControl;
