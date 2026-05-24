import Box from "@mui/material/Box";
import Typography from "@mui/material/Typography";
import Button from "@mui/material/Button";
import wallpaper from "../../public/Wallpaper.jpg";

export default function HeroSection() {
  return (
    <>
      <Box
        sx={{
          backgroundImage: `url(${wallpaper})`,
          backgroundSize: "cover",
          backgroundPosition: "center top",
          color: "#fff",
          py: 14,
          textAlign: "center",
          position: "relative",
          "&::after": {
            content: '""',
            position: "absolute",
            inset: 0,
            background: "rgba(0,0,0,0.45)",
          },
        }}
      >
        <Box sx={{ position: "relative", zIndex: 1 }}>
          <Typography
            variant="h2"
            sx={{ fontWeight: 700, mb: 3, letterSpacing: 1 }}
          >
            Welcome Hero 🥷
          </Typography>
          <Button
            variant="contained"
            sx={{
              background: "linear-gradient(90deg,#a855f7,#6366f1)",
              px: 4,
              py: 1,
              fontWeight: 700,
              letterSpacing: 1,
              borderRadius: 1,
            }}
          >
            GET STARTED
          </Button>
        </Box>
      </Box>
    </>
  );
}
