import Card from "@mui/material/Card";
import CardMedia from "@mui/material/CardMedia";
import CardContent from "@mui/material/CardContent";
import Box from "@mui/material/Box";
import Container from "@mui/material/Container";
import Grid from "@mui/material/Grid";
import Typography from "@mui/material/Typography";
import wallpaper from "../../src/assets/Wallpaper.jpg";
import Stack from "@mui/material/Stack";

const cards = [1, 2, 3, 4, 5, 6];
export default function CardList() {
  return (
    <>
      <Box sx={{ py: 6 }}>
        <Container maxWidth="lg">
          <Typography
            sx={{
              fontWeight: 600,
              fontSize: { xs: 20, sm: 24 },
              textAlign:"center",
              marginBottom:4
            }}
          >
            Our Menu
          </Typography>
          <Grid container spacing={3}>
            {cards.map((c) => (
              <Grid size={{ xs: 12, sm: 6, md: 4 }} key={c}>
                <Card
                  sx={{
                    borderRadius: 2,
                    overflow: "hidden",
                    maxWidth: "350px",
                    mx: "auto",
                    "&:hover": {
                      boxShadow: "0 12px 24px rgba(0,0,0,0.5)",
                      transform: "scale(1.01)",
                    },
                  }}
                >
                  <CardMedia
                    component="img"
                    height="170"
                    image={wallpaper}
                    alt={`Spider Card`}
                    sx={{ objectPosition: "center top" }}
                  />
                  <CardContent>
                    <Stack direction="column" spacing={4}>
                      <Box>
                        <Typography variant="h6" sx={{ fontWeight: 600 }}>
                          Grilled Salmon
                        </Typography>
                        <Typography variant="body2" sx={{ mt: 0.5 }}>
                          Freshly grilled salmon with herbs.
                        </Typography>
                      </Box>
                      <Typography variant="body2" sx={{ fontWeight: 600 }}>
                        $15.55
                      </Typography>
                    </Stack>
                  </CardContent>
                </Card>
              </Grid>
            ))}
          </Grid>
        </Container>
      </Box>
    </>
  );
}
