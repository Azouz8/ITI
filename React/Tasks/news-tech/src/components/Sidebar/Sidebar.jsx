import { Component } from "react";
import styles from "./Sidebar.module.css";

class Sidebar extends Component {
  constructor(props) {
    super(props);
    this.state = {
      category: "",
      title: "",
      description: "",
      imgUrl: "src/assets/post1.jpg",
    };
  }

  handleOnChange = (e) => {
    this.setState({ ...this.state, [e.target.name]: e.target.value });
  };

  handleSubmit = () => {
    this.props.getPostData(this.state);
    this.setState({
      category: "",
      title: "",
      description: "",
      likeCount: 0,
      dislikeCount: 0,
      commentCount: 0,
      shareCount: 0,
      imgUrl: "src/assets/post1.jpg",
    });
  };

  render() {
    return (
      <div className={styles.sidebar}>
        <h4 className={styles.title}>What is in Ur mind?!</h4>

        <div className={styles.field}>
          <input
            type="text"
            className={styles.input}
            placeholder="Category"
            name="category"
            value={this.state.category}
            onChange={this.handleOnChange}
          />
        </div>
        <div className={styles.field}>
          <input
            type="text"
            className={styles.input}
            placeholder="News Title"
            name="title"
            value={this.state.title}
            onChange={this.handleOnChange}
          />
        </div>
        <div className={styles.field}>
          <textarea
            className={styles.textarea}
            placeholder="Description"
            name="description"
            value={this.state.description}
            onChange={this.handleOnChange}
            rows="4"
          ></textarea>
        </div>
        <button onClick={this.handleSubmit} className={styles.btn}>
          Submit
        </button>
      </div>
    );
  }
}

// const Sidebar = () => {
//   return (
//     <div className="sidebar">
//       <h4 className="sidebar-title">New Article</h4>

//       <div className="sidebar-field">
//         <input type="text" className="sidebar-input" placeholder="Category" />
//       </div>

//       <div className="sidebar-field">
//         <input type="text" className="sidebar-input" placeholder="News Title" />
//       </div>

//       <div className="sidebar-field">
//         <textarea
//           className="sidebar-textarea"
//           placeholder="Description"
//           rows="4"
//         ></textarea>
//       </div>

//       <button className="sidebar-btn">Submit</button>
//     </div>
//   );
// };

export default Sidebar;
