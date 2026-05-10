import { Link } from "react-router-dom";

function Navbar() {
  return (
    <nav style={styles.nav}>
      <h2 style={styles.brand}>Departments Dashboard</h2>
      <div style={styles.links}>
        <Link to="/add-department" style={styles.link}>
          Add Department
        </Link>
        <Link to="/departments" style={styles.link}>
          View Departments
        </Link>
      </div>
    </nav>
  );
}

const styles = {
  nav: {
    display: "flex",
    justifyContent: "space-between",
    alignItems: "center",
    backgroundColor: "#2c3e50",
    padding: "14px 32px",
  },
  brand: {
    color: "#fff",
    margin: 0,
  },
  links: {
    display: "flex",
    gap: "24px",
  },
  link: {
    color: "#ecf0f1",
    textDecoration: "none",
    fontSize: "16px",
  },
};

export default Navbar;
