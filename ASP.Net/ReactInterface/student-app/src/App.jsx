import { BrowserRouter, Routes, Route, Navigate } from "react-router-dom";
import Navbar from "./components/Navbar";
import AddDepartment from "./pages/AddDepartmentPage";
import ViewDepartments from "./pages/ViewDepartments";

function App() {
  return (
    <BrowserRouter>
      <Navbar />
      <Routes>
        <Route path="/" element={<Navigate to="/departments" />} />
        <Route path="/add-department" element={<AddDepartment />} />
        <Route path="/departments" element={<ViewDepartments />} />
      </Routes>
    </BrowserRouter>
  );
}

export default App;
