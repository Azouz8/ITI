// src/pages/AddDepartment.jsx
import { useState } from "react";
import axios from "axios";

function AddDepartment() {
  const [form, setForm] = useState({
    name: "",
    location: "",
    phoneNo: "",
    manager: "",
  });
  const [message, setMessage] = useState("");
  const [error, setError] = useState("");

  function handleChange(e) {
    setForm({ ...form, [e.target.name]: e.target.value });
  }

  function handleSubmit(e) {
    e.preventDefault();
    setMessage("");
    setError("");

    axios
      .post("https://localhost:7059/api/Department", form)
      .then(() => {
        setMessage("Department added successfully!");
        setForm({ name: "", location: "", phoneNo: "", manager: "" });
      })
      .catch((err) => {
        setError(err.response?.data || "Something went wrong");
      });
  }

  return (
    <div style={styles.container}>
      <h2>Add Department</h2>

      {message && <p style={styles.success}>{message}</p>}
      {error && <p style={styles.error}>{error}</p>}

      <form onSubmit={handleSubmit} style={styles.form}>
        <label>Name</label>
        <input
          name="name"
          value={form.name}
          onChange={handleChange}
          required
          style={styles.input}
        />

        <label>Location</label>
        <input
          name="location"
          value={form.location}
          onChange={handleChange}
          required
          style={styles.input}
        />

        <label>Phone Number</label>
        <input
          name="phoneNo"
          value={form.phoneNo}
          onChange={handleChange}
          required
          style={styles.input}
        />

        <label>Manager</label>
        <input
          name="manager"
          value={form.manager}
          onChange={handleChange}
          required
          style={styles.input}
        />

        <button type="submit" style={styles.button}>
          Add Department
        </button>
      </form>
    </div>
  );
}

const styles = {
  container: { maxWidth: "500px", margin: "40px auto", padding: "0 16px" },
  form: { display: "flex", flexDirection: "column", gap: "12px" },
  input: {
    padding: "10px",
    fontSize: "15px",
    borderRadius: "6px",
    border: "1px solid #ccc",
  },
  button: {
    padding: "12px",
    backgroundColor: "#2c3e50",
    color: "#fff",
    border: "none",
    borderRadius: "6px",
    fontSize: "16px",
    cursor: "pointer",
  },
  success: { color: "green" },
  error: { color: "red" },
};

export default AddDepartment;
