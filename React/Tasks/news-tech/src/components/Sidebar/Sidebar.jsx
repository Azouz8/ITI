import { Component } from "react";
import styles from "./Sidebar.module.css";

class Sidebar extends Component {
  render() {
    return (
      <div className={styles.sidebar}>
        <h4 className={styles.title}>What is in Ur mind?!</h4>

        <div className={styles.field}>
          <input type="text" className={styles.input} placeholder="Category" />
        </div>

        <div className={styles.field}>
          <input
            type="text"
            className={styles.input}
            placeholder="News Title"
          />
        </div>

        <div className={styles.field}>
          <textarea
            className={styles.textarea}
            placeholder="Description"
            rows="4"
          ></textarea>
        </div>

        <button className={styles.btn}>Submit</button>
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
