import Card from "@mui/material/Card";
import CardMedia from "@mui/material/CardMedia";
import CardContent from "@mui/material/CardContent";
import CardActions from "@mui/material/CardActions";
import Box from "@mui/material/Box";
import Container from "@mui/material/Container";
import Grid from "@mui/material/Grid";
import Typography from "@mui/material/Typography";
import Button from "@mui/material/Button";
import wallpaper from "../../src/assets/Wallpaper.jpg";

const cards = [1, 2, 3, 4, 5, 6];
export default function CardList() {
  return (
    <>
      <Box sx={{ background: "#12132a", py: 6 }}>
        <Container maxWidth="lg">
          <Grid container spacing={3}>
            {cards.map((c) => (
              <Grid item xs={12} sm={6} md={4} key={c}>
                <Card
                  sx={{
                    background: "#1f2340",
                    borderRadius: 2,
                    overflow: "hidden",
                    "&:hover": {
                      boxShadow: "0 12px 32px rgba(0,0,0,0.5)",
                      scale: "1.02",
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
                    <Typography variant="h6" sx={{ color: "#fff" }}>
                      Devil Card
                    </Typography>
                    <Typography
                      variant="body2"
                      sx={{ color: "rgba(255,255,255,0.65)", mt: 0.5 }}
                    >
                      Creative modern UI design with hover animation.
                    </Typography>
                  </CardContent>
                  <CardActions sx={{ justifyContent: "center", pb: 2 }}>
                    <Button
                      variant="contained"
                      color="error"
                      sx={{ px: 5, fontWeight: 700, letterSpacing: 1 }}
                    >
                      EXPLORE
                    </Button>
                  </CardActions>
                </Card>
              </Grid>
            ))}
          </Grid>
        </Container>
      </Box>
    </>
  );
}
