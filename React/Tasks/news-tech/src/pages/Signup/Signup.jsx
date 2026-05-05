import axios from "axios";
import styles from "./Signup.module.css";
import { useNavigate } from "react-router";
import toast from "react-hot-toast";
import { useForm } from "react-hook-form";

const Signup = () => {
  const navigateTo = useNavigate();
  const goToLogin = () => {
    navigateTo("/login", { replace: true });
  };

  const {
    register,
    handleSubmit,
    formState: { errors },
    getValues,
  } = useForm();

  const onSubmit = ({ name, email, password }) => {
    const user = {
      name: name,
      email: email.toLocaleLowerCase(),
      password: password,
    };
    axios.get("http://localhost:3000/users").then((res) => {
      const alreadyExist = res.data.find(
        (u) => u.email.toLowerCase() === email.toLowerCase(),
      );

      if (alreadyExist) {
        toast.error("Account with this email already exists!");
        return;
      }
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
    });
  };

  return (
    <>
      <div className={styles.container}>
        <form className={styles.form} onSubmit={handleSubmit(onSubmit)}>
          <h4 className="text-light text-center mb-3 fw-bold">Sign Up</h4>
          <div className={styles.inputField}>
            <input
              type="text"
              name="name"
              placeholder="Full Name"
              className={`form-control ${errors.name ? "is-invalid" : ""}`}
              {...register("name", {
                required: "Name is required!",
                minLength: { value: 3, message: "Minimum 3 characters" },
              })}
            />
            {errors.name && (
              <div className="invalid-feedback">{errors.name.message}</div>
            )}
          </div>
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
          <div className={styles.inputField}>
            <input
              name="confirmPassword"
              type="password"
              placeholder="Confirm Password"
              className={`form-control ${errors.confirmPassword ? "is-invalid" : ""}`}
              {...register("confirmPassword", {
                required: "Please confirm your password",
                validate: (value) =>
                  value === getValues("password") || "Passwords don't match",
              })}
            />
            {errors.confirmPassword && (
              <div className="invalid-feedback">
                {errors.confirmPassword.message}
              </div>
            )}
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
