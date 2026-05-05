import { useContext, useState } from "react";
import styles from "./Sidebar.module.css";
import { PostsContext } from "../../context/PostsContext";

const Sidebar = () => {
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

  const { getPostData } = useContext(PostsContext);
  const [inputData, setInputData] = useState(initialState);
  const [errors, setErrors] = useState({});

  const handleOnChange = (e) => {
    const { name, value } = e.target;
    setInputData({ ...inputData, [name]: value });
    if (errors[name]) {
      setErrors({ ...errors, [name]: "" });
    }
  };

  const validate = () => {
    const newErrors = {};

    if (!inputData.category.trim()) {
      newErrors.category = "Category is required";
    }

    if (!inputData.title.trim()) {
      newErrors.title = "Title is required";
    } else if (inputData.title.trim().length < 3) {
      newErrors.title = "Title must be at least 3 characters";
    }

    if (!inputData.description.trim()) {
      newErrors.description = "Description is required";
    } else if (inputData.description.trim().length < 10) {
      newErrors.description = "Description must be at least 10 characters";
    }

    return newErrors;
  };

  const handleSubmit = () => {
    const validationErrors = validate();
    if (Object.keys(validationErrors).length > 0) {
      setErrors(validationErrors);
      return;
    }

    getPostData(inputData);
    setInputData(initialState);
    setErrors({});
  };

  return (
    <>
      <div className={styles.sidebar}>
        <h4 className={styles.title}>What is in Ur mind?!</h4>

        <div className={styles.field}>
          <input
            type="text"
            className={`${styles.input} ${errors.category ? styles.errorInput : ""}`}
            placeholder="Category"
            name="category"
            value={inputData.category}
            onChange={handleOnChange}
          />
          {errors.category && (
            <p className={styles.errorMsg}>{errors.category}</p>
          )}
        </div>
        <div className={styles.field}>
          <input
            type="text"
            className={`${styles.input} ${errors.title ? styles.errorInput : ""}`}
            placeholder="News Title"
            name="title"
            value={inputData.title}
            onChange={handleOnChange}
          />
          {errors.title && <p className={styles.errorMsg}>{errors.title}</p>}
        </div>
        <div className={styles.field}>
          <textarea
            className={`${styles.textarea} ${errors.description ? styles.errorInput : ""}`}
            placeholder="Description"
            name="description"
            value={inputData.description}
            onChange={handleOnChange}
            rows="4"
          ></textarea>
          {errors.description && (
            <p className={styles.errorMsg}>{errors.description}</p>
          )}
        </div>
        <button onClick={handleSubmit} className={styles.btn}>
          Submit
        </button>
      </div>
    </>
  );
};

export default Sidebar;
