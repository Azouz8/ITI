import { useNavigate } from "react-router";
import styles from "./Login.module.css";
import axios from "axios";
import toast from "react-hot-toast";
const Login = () => {
  const navigateTo = useNavigate();
  const goToRegister = () => {
    navigateTo("/signup");
  };

  const handleSubmit = (e) => {
    e.preventDefault();

    const formData = new FormData(e.target);

    const email = formData.get("email").toLocaleLowerCase();
    const password = formData.get("password");

    axios.get("http://localhost:3000/users").then((res) => {
      const user = res.data.find(
        (u) => u.email === email && u.password === password,
      );

      if (user) {
        localStorage.setItem("user", JSON.stringify(user));
        toast("Welcome Back!", {
          icon: "😍",
        });
        setTimeout(() => {
          navigateTo("/", { replace: true });
        }, 1000);
      } else {
        alert("Invalid User Data");
      }
    });
  };
  return (
    <>
      <div className={styles.container}>
        <form className={styles.form} onSubmit={handleSubmit}>
          <h4 className="text-light text-center mb-3 fw-bold">Login</h4>
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
              type="text"
              name="password"
              type="password"
              placeholder="Password"
              className="form-control"
              required
              minLength="3"
            />
          </div>
          <div
            className={
              styles.inputField +
              " d-flex align-items-center justify-content-start gap-2"
            }
          >
            <input
              name="rememberMe"
              className="form-check-input"
              type="checkbox"
              value=""
              id="flexCheckDefault"
            />
            <label htmlFor="flexCheckDefault" className="text-light">
              Remember me
            </label>
          </div>
          <input type="submit" value="Submit" className="btn btn-secondary" />
          <a onClick={goToRegister} className={styles.link}>
            <p className="text-light text-center mb-3">
              Don't have an account?
            </p>
          </a>
        </form>
      </div>
    </>
  );
};

export default Login;
