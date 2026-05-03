import { useState } from "react";
import styles from "./Sidebar.module.css";

const Sidebar = ({ getPostData }) => {
  const initialState = {
    category: "",
    title: "",
    description: "",
    likeCount: 0,
    dislikeCount: 0,
    commentCount: 0,
    shareCount: 0,
    imgUrl: "src/assets/post1.jpg",
  };
  const [inputData, setInputData] = useState(initialState);

  const handleOnChange = (e) => {
    setInputData({ ...inputData, [e.target.name]: e.target.value });
  };

  const handleSubmit = () => {
    if (!inputData.title || !inputData.description) {
      return alert("Title and description are required");
    }
    getPostData(inputData);
    setInputData(initialState);
  };

  return (
    <>
      <div className={styles.sidebar}>
        <h4 className={styles.title}>What is in Ur mind?!</h4>

        <div className={styles.field}>
          <input
            type="text"
            className={styles.input}
            placeholder="Category"
            name="category"
            value={inputData.category}
            onChange={handleOnChange}
          />
        </div>
        <div className={styles.field}>
          <input
            type="text"
            className={styles.input}
            placeholder="News Title"
            name="title"
            value={inputData.title}
            onChange={handleOnChange}
          />
        </div>
        <div className={styles.field}>
          <textarea
            className={styles.textarea}
            placeholder="Description"
            name="description"
            value={inputData.description}
            onChange={handleOnChange}
            rows="4"
          ></textarea>
        </div>
        <button onClick={handleSubmit} className={styles.btn}>
          Submit
        </button>
      </div>
    </>
  );
};

export default Sidebar;
