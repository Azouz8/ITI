import { useState } from "react";
import styles from "./Carousel.module.css";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faChevronLeft,
  faChevronRight,
} from "@fortawesome/free-solid-svg-icons";

const Carousel = () => {
  const [images, setImages] = useState([
    "src/assets/Wallpaper1.jpg",
    "src/assets/Wallpaper2.jpg",
    "src/assets/Wallpaper3.jpg",
    "src/assets/Wallpaper4.jpg",
  ]);
  const [current, setCurrent] = useState(0);

  const moveForward = () => {
    setCurrent((prev) => (prev + 1) % images.length);
  };

  const moveBackward = () => {
    setCurrent((prev) => (prev - 1 + images.length) % images.length);
  };

  const goToSlide = (index) => {
    setCurrent(index);
  };

  // useEffect(() => {
  //   let CarouselInterval = setInterval(() => {
  //     moveForward();
  //   }, 2000);

  //   return () => {
  //     clearInterval(CarouselInterval);
  //   };
  // }, []);
  return (
    <>
      <div className={styles.wrapper}>
        <div className={styles.carousel}>
          <button type="button" className={styles.btn} onClick={moveBackward}>
            <FontAwesomeIcon icon={faChevronLeft} />
          </button>
          {images.map((img, index) => (
            <img
              key={index}
              className={`${styles.img} ${current !== index ? styles.hiddenImg : ""}`}
              src={img}
              alt="carousel slide"
            />
          ))}
          <button type="button" className={styles.btn} onClick={moveForward}>
            <FontAwesomeIcon icon={faChevronRight} />
          </button>
        </div>
        <div className={styles.indicator}>
          {}
          {images.map((_, index) => (
            <div
              key={index}
              className={`${styles.dot} ${current === index ? styles.active : ""}`}
              onClick={() => goToSlide(index)}
            ></div>
          ))}
        </div>
      </div>
    </>
  );
};

export default Carousel;
