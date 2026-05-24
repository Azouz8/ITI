import Typography from "@mui/material/Typography";
import Button from "@mui/material/Button";
import AppBar from "@mui/material/AppBar";
import Toolbar from "@mui/material/Toolbar";

export default function CustomAppBar() {
  return (
    <>
      <AppBar
        position="static"
        elevation={0}
        sx={{
          background: "linear-gradient(90deg, #ff4e4e 0%, #7c4dff 100%)",
        }}
      >
        <Toolbar sx={{ justifyContent: "space-between" }}>
          <Typography variant="h6" sx={{ fontWeight: 700 }}>
            🕷️ Daredevil UI
          </Typography>
          <Button
            variant="outlined"
            sx={{
              color: "#fff",
              borderColor: "#fff",
              fontWeight: 700,
              letterSpacing: 1,
              "&:hover": { background: "rgba(255,255,255,0.1)" },
            }}
          >
            LOGIN
          </Button>
        </Toolbar>
      </AppBar>
    </>
  );
}
