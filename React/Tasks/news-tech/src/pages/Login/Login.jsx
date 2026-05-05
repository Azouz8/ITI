import { useNavigate } from "react-router";
import styles from "./Login.module.css";
import axios from "axios";
import toast from "react-hot-toast";
import { useForm } from "react-hook-form";
const Login = () => {
  const navigateTo = useNavigate();
  const goToRegister = () => {
    navigateTo("/signup");
  };

  const {
    register,
    handleSubmit,
    formState: { errors },
  } = useForm();

  const onSubmit = ({ email, password }) => {
    axios.get("http://localhost:3000/users").then((res) => {
      const user = res.data.find(
        (u) =>
          u.email.toLowerCase() === email.toLowerCase() &&
          u.password === password,
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
        toast.error("Invalid Email Address or Password!");
      }
    });
  };

  return (
    <>
      <div className={styles.container}>
        <form className={styles.form} onSubmit={handleSubmit(onSubmit)}>
          <h4 className="text-light text-center mb-3 fw-bold">Login</h4>
          <div className={styles.inputField}>
            <input
              type="email"
              name="email"
              placeholder="Email Address"
              className={`form-control ${errors.email ? "is-invalid" : ""}`}
              {...register("email", {
                required: "Email is required!",
                pattern: {
                  value: /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/,
                  message: "Enter a valid email address",
                },
              })}
            />
            {errors.email && (
              <div className="invalid-feedback">{errors.email.message}</div>
            )}
          </div>
          <div className={styles.inputField}>
            <input
              name="password"
              type="password"
              placeholder="Password"
              className={`form-control ${errors.password ? "is-invalid" : ""}`}
              {...register("password", {
                required: "Password is required",
                minLength: { value: 3, message: "Minimum 3 characters" },
              })}
            />
            {errors.password && (
              <div className="invalid-feedback">{errors.password.message}</div>
            )}
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
