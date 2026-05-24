import CssBaseline from "@mui/material/CssBaseline";
import { createTheme, ThemeProvider } from "@mui/material/styles";
import CustomAppBar from "./components/AppBar";
import HeroSection from "./components/HeroSection";
import CardList from "./components/CardList";
import SpeedDesignResp from "./components/SpeedDesignResp";
import Footer from "./components/Footer";

const theme = createTheme({
  palette: {
    mode: "dark",
    background: {
      default: "#12132a",
      paper: "#1f2340",
    },
  },
});

export default function App() {
  return (
    <ThemeProvider theme={theme}>
      <CssBaseline />
      <CustomAppBar />
      <HeroSection />
      <CardList />
      <SpeedDesignResp />
      <Footer />
    </ThemeProvider>
  );
}
