// src/pages/ViewDepartments.jsx
import { useEffect, useState } from "react";
import axios from "axios";

function ViewDepartments() {
  const [departments, setDepartments] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");

  useEffect(() => {
    axios
      .get("https://localhost:7059/api/Department")
      .then((res) => {
        setDepartments(res.data);
        setLoading(false);
      })
      .catch(() => {
        setError("Failed to load departments");
        setLoading(false);
      });
  }, []);

  if (loading) return <p style={styles.center}>Loading...</p>;
  if (error) return <p style={{ ...styles.center, color: "red" }}>{error}</p>;

  return (
    <div style={styles.container}>
      <h2>All Departments</h2>
      {departments.length === 0 ? (
        <p>No departments found.</p>
      ) : (
        departments.map((dept) => (
          <div key={dept.id} style={styles.card}>
            <div style={styles.cardHeader}>
              <h3 style={styles.deptName}>{dept.departmentName}</h3>
              <span
                style={{
                  ...styles.badge,
                  backgroundColor:
                    dept.message === "Overload" ? "#e74c3c" : "#27ae60",
                }}
              >
                {dept.message}
              </span>
            </div>
            <p style={styles.count}>Students: {dept.studentsCount}</p>
            {dept.listOfStudentsNames.length > 0 ? (
              <ul style={styles.list}>
                {dept.listOfStudentsNames.map((name, i) => (
                  <li key={i}>{name}</li>
                ))}
              </ul>
            ) : (
              <p style={styles.noStudents}>No students assigned</p>
            )}
          </div>
        ))
      )}
    </div>
  );
}

const styles = {
  container: { maxWidth: "700px", margin: "40px auto", padding: "0 16px" },
  center: { textAlign: "center", marginTop: "40px" },
  card: {
    border: "1px solid #ddd",
    borderRadius: "10px",
    padding: "20px",
    marginBottom: "16px",
  },
  cardHeader: {
    display: "flex",
    justifyContent: "space-between",
    alignItems: "center",
  },
  deptName: { margin: 0 },
  badge: {
    color: "#fff",
    padding: "4px 12px",
    borderRadius: "20px",
    fontSize: "13px",
  },
  count: { color: "#555", margin: "8px 0" },
  list: { paddingLeft: "20px" },
  noStudents: { color: "#999", fontStyle: "italic" },
};

export default ViewDepartments;
