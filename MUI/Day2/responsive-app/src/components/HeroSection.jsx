import Box from "@mui/material/Box";
import Typography from "@mui/material/Typography";
import Button from "@mui/material/Button";
import wallpaper from "../../src/assets/Wallpaper.jpg";

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
            sx={{
              fontWeight: 500,
              letterSpacing: 1,
              fontSize: { xs: 28, sm: 36, md: 42, lg: 48 },
            }}
          >
            Welcome to out Resturatant
          </Typography>
          <Typography
            variant="h2"
            sx={{
              fontWeight: 200,
              mb: 3,
              letterSpacing: 1,
              fontSize: { xs: 12, sm: 16, md: 20, lg: 24 },
            }}
          >
            Welcome to out Resturatant
          </Typography>
          <Button
            variant="contained"
            sx={{
              backgroundColor: "#0e6efa",
              color: "#ffffff",
              px: 4,
              py: 1,
              fontWeight: 500,
              letterSpacing: 1,
              borderRadius: 1,
              textTransform: "none",
            }}
          >
            View Menu
          </Button>
        </Box>
      </Box>
    </>
  );
}
