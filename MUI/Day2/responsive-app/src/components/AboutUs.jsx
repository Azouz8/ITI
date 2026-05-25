import Box from "@mui/material/Box";
import Stack from "@mui/material/Stack";
import wallpaper from "../../src/assets/Wallpaper.jpg";
import Typography from "@mui/material/Typography";
import ContactUs from "./ContactUs";

export default function AboutUs() {
  return (
    <>
      <Box
        sx={{
          bgcolor: "#f8f9fb",
          p: { xs: 2, xm: 4, lg: 10 },
          marginInline: { xs: 0, md: 24 },
          borderRadius: 8,
        }}
      >
        <Stack
          spacing={3}
          direction={{ xs: "column", md: "row" }}
          sx={{
            justifyContent: { xs: "center" },
            alignItems: { xs: "center" },
            paddingInline: { md: 10 },
            paddingBlock: { md: 4 },
          }}
        >
          <Box
            component="img"
            src={wallpaper}
            sx={{
              width: { xs: "100%", sm: "60%", md: "40%", lg: "35%" },
              height: 180,
              borderRadius: 2,
              objectFit: "cover",
            }}
          />
          <Stack direction="column" spacing={1} sx={{ width: "100%" }}>
            <Typography
              sx={{
                fontWeight: 550,
                fontSize: { xs: 20, sm: 24 },
              }}
            >
              About US
            </Typography>
            <Typography
              sx={{
                fontSize: { xs: 14, sm: 16 },
              }}
            >
              We are a family-owned restaurant dedicated to serving delicious,
              high-quality meals made from fresh, locally sourced ingredients.
              Our mission is to provide an unforgettable dining experience for
              every guest.
            </Typography>
          </Stack>
        </Stack>
        <ContactUs />
      </Box>
    </>
  );
}
