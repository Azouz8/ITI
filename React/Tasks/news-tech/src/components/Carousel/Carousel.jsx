import { Component } from "react";
import styles from "./Carousel.module.css";

class Carousel extends Component {
  constructor(props) {
    super(props);
    this.state = {
      imgs: [
        "src/assets/Wallpaper1.jpg",
        "src/assets/Wallpaper2.jpg",
        "src/assets/Wallpaper3.jpg",
        "src/assets/Wallpaper4.jpg",
      ],
      current: 0,
      isAutomated: false,
    };
  }

  moveForward = () => {
    this.setState((prevState) => ({
      current: (prevState.current + 1) % prevState.imgs.length,
    }));
  };
  moveBackward = () => {
    this.setState({
      current:
        (this.state.current - 1 + this.state.imgs.length) %
        this.state.imgs.length,
    });
  };
  goToSlide = (index) => {
    this.setState({ current: index });
  };
  automateCarousel = () => {
    this.timer = setInterval(() => {
      this.moveForward();
    }, 2000);
  };
  // componentDidMount() {
  //   this.automateCarousel();
  // }
  componentWillUnmount() {
    if (this.timer) clearInterval(this.timer);
  }
  render() {
    return (
      <div className={styles.wrapper}>
        <div className={styles.carousel}>
          <button
            type="button"
            className={styles.btn}
            onClick={this.moveBackward}
          >
            &#8249;
          </button>
          {this.state.imgs.map((img, index) => (
            <img
              key={index}
              className={`${styles.img} ${this.state.current !== index ? styles.hiddenImg : ""}`}
              src={img}
              alt="carousel slide"
            />
          ))}
          <button
            type="button"
            className={styles.btn}
            onClick={this.moveForward}
          >
            &#8250;
          </button>
        </div>
        <div className={styles.indicator}>
          {this.state.imgs.map((_, index) => (
            <div
              key={index}
              className={`${styles.dot} ${this.state.current === index ? styles.active : ""}`}
              onClick={() => this.goToSlide(index)}
            ></div>
          ))}
        </div>
      </div>
    );
  }
}

export default Carousel;
