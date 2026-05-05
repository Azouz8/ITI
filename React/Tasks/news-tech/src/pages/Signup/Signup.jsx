import axios from "axios";
import styles from "./Signup.module.css";
import { useNavigate } from "react-router";
import toast from "react-hot-toast";

const Signup = () => {
  const navigateTo = useNavigate();
  const goToLogin = () => {
    navigateTo("/login", { replace: true });
  };

  const handleSubmit = (e) => {
    e.preventDefault();
    const formData = new FormData(e.target);
    const user = {
      name: formData.get("name"),
      email: formData.get("email").toLocaleLowerCase(),
      password: formData.get("password"),
    };
    axios
      .post("http://localhost:3000/users", user)
      .then(() => {
        toast.success("Account Created Successfully! 🎉");
        setTimeout(() => {
          goToLogin();
        }, 2000);
      })
      .catch((err) => {
        console.log(err);
      });
  };
  return (
    <>
      <div className={styles.container}>
        <form className={styles.form} onSubmit={handleSubmit}>
          <h4 className="text-light text-center mb-3 fw-bold">Sign Up</h4>
          <div className={styles.inputField}>
            <input
              type="text"
              name="name"
              placeholder="Full Name"
              className="form-control"
              required
            />
          </div>
          <div className={styles.inputField}>
            <input
              type="email"
              name="email"
              placeholder="Email Address"
              className="form-control"
              required
              pattern="^[a-zA-Z0-9._%+\-]+@[a-zA-Z0-9.\-]+\.[a-zA-Z]{2,}$"
            />
          </div>
          <div className={styles.inputField}>
            <input
              name="password"
              type="password"
              placeholder="Password"
              className="form-control"
              required
              minLength="3"
            />
          </div>
          <div className={styles.inputField}>
            <input
              name="confirmPassword"
              type="password"
              placeholder="Confirm Password"
              className="form-control"
              required
              minLength="3"
            />
          </div>

          <input type="submit" value="Submit" className="btn btn-secondary" />
          <a onClick={goToLogin} className={styles.link}>
            <p className="text-light text-center mb-3">
              Already have an account?
            </p>
          </a>
        </form>
      </div>
    </>
  );
};

export default Signup;
