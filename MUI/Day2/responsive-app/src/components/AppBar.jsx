import AppBar from "@mui/material/AppBar";
import Toolbar from "@mui/material/Toolbar";
import Typography from "@mui/material/Typography";
import Stack from "@mui/material/Stack";
import Box from "@mui/material/Box";
import MenuIcon from "@mui/icons-material/Menu";
import IconButton from "@mui/material/IconButton";

export default function CustomAppBar() {
  return (
    <>
      <AppBar
        position="static"
        elevation={0}
        sx={{
          backgroundColor: "#212429",
        }}
      >
        <Toolbar
          disableGutters
          sx={{
            justifyContent: "space-between",
            paddingInline: { xs: 2, sm: 4, md: 6, lg: 10 },
          }}
        >
          <Typography
            sx={{ color: "lightgrey", fontWeight: 600, fontSize: 16 }}
          >
            Resturant
          </Typography>
          <Box sx={{ display: { xs: "none", sm: "block" } }}>
            <Stack direction="row" spacing={3}>
              <Typography
                sx={{ color: "lightgrey", fontWeight: 600, fontSize: 14 }}
              >
                Home
              </Typography>
              <Typography
                sx={{ color: "lightgrey", fontWeight: 600, fontSize: 14 }}
              >
                Menu
              </Typography>
              <Typography
                sx={{ color: "lightgrey", fontWeight: 600, fontSize: 14 }}
              >
                About
              </Typography>
              <Typography
                sx={{ color: "lightgrey", fontWeight: 600, fontSize: 14 }}
              >
                Contact
              </Typography>
            </Stack>
          </Box>
          <Box
            sx={{
              display: {
                xs: "block",
                sm: "none",
                md: "none",
                lg: "none",
              },
            }}
          >
            <IconButton
              sx={{
                "&:hover": {
                  backgroundColor: "rgba(255,255,255,0.1)",
                },
              }}
            >
              <MenuIcon sx={{ color: "lightgrey" }} />
            </IconButton>
          </Box>
        </Toolbar>
      </AppBar>
    </>
  );
}
