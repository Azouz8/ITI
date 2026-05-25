import CssBaseline from "@mui/material/CssBaseline";
import "./App.css";
import CustomAppBar from "./components/AppBar";
import HeroSection from "./components/HeroSection";
import CardList from "./components/CardList";
import AboutUs from "./components/AboutUs";

function App() {
  return (
    <>
      <CssBaseline />
      <CustomAppBar />
      <HeroSection />
      <CardList />
      <AboutUs />
    </>
  );
}

export default App;
