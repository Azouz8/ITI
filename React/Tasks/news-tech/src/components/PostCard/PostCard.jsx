import { Component } from "react";
import styles from "./PostCard.module.css";
import PostControl from "./../PostControls/PostControl";

class Post extends Component {
  constructor(props) {
    super(props);
  }
  render() {
    return (
      <div className={styles.card}>
        <img
          className={styles.img}
          src={this.props.imageUrl}
          alt="Card image cap"
        />
        <div className={styles.body}>
          <h5 className={styles.title}>{this.props.title}</h5>
          <p className={styles.text}>{this.props.description}</p>
        </div>
        <div className={styles.controls}>
          <PostControl
            id={this.props.id}
            likeCount={this.props.likeCount}
            dislikeCount={this.props.dislikeCount}
            commentCount={this.props.commentCount}
            shareCount={this.props.shareCount}
            onUpdate={this.props.onUpdate}
          />
        </div>
      </div>
    );
  }
}

// const Card = ({ title, description, id }) => {
//   return (
//     <div className="card">
//       <img
//         className="card-img"
//         src="src/assets/react.png"
//         alt="Card image cap"
//       />
//       <div className="card-body">
//         <h5 className="card-title">{title}</h5>
//         <p className="card-text">{description}</p>
//       </div>
//     </div>
//   );
// };

export default Post;
