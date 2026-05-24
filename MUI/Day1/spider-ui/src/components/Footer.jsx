import Typography from "@mui/material/Typography";
import Button from "@mui/material/Button";
import Box from "@mui/material/Box";

export default function Footer() {
  return (
    <div>
      <Box
        sx={{
          background: "linear-gradient(90deg, #ff6b6b 0%, #7c4dff 100%)",
          py: 8,
          textAlign: "center",
        }}
      >
        <Typography variant="h4" sx={{ color: "#fff", fontWeight: 700, mb: 3 }}>
          Ready to build something awesome?
        </Typography>
        <Button
          variant="contained"
          sx={{
            bgcolor: "#000",
            color: "#fff",
            px: 4,
            fontWeight: 700,
            letterSpacing: 1,
            "&:hover": { bgcolor: "#222" },
          }}
        >
          JOIN NOW 🚀
        </Button>
      </Box>
    </div>
  );
}
