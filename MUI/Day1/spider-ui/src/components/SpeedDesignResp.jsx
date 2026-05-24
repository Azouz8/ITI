import Container from "@mui/material/Container";
import Grid from "@mui/material/Grid";
import Paper from "@mui/material/Paper";
import Box from "@mui/material/Box";
import Typography from "@mui/material/Typography";

export default function SpeedDesignResp() {
  return (
    <>
      <Box
        sx={{
          background: "linear-gradient(90deg, #66ccff 0%, #a366ff 100%)",
          py: 5,
        }}
      >
        <Container maxWidth="lg">
          <Grid container spacing={2}>
            {[
              { icon: "⚡", title: "Speed" },
              { icon: "🎨", title: "Design" },
              { icon: "📱", title: "Responsive" },
            ].map((f) => (
              <Grid item xs={12} md={4} key={f.title}>
                <Paper
                  elevation={0}
                  sx={{
                    p: 3,
                    background: "rgba(255,255,255,0.15)",
                    backdropFilter: "blur(8px)",
                    textAlign: "center",
                    color: "#fff",
                  }}
                >
                  <Typography variant="h6" sx={{ fontWeight: 700 }}>
                    {f.title} {f.icon}
                  </Typography>
                  <Typography variant="body2" sx={{ opacity: 0.85, mt: 0.5 }}>
                    Amazing experience with modern UI.
                  </Typography>
                </Paper>
              </Grid>
            ))}
          </Grid>
        </Container>
      </Box>
    </>
  );
}
