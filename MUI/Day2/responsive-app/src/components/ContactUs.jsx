import Button from "@mui/material/Button";
import Stack from "@mui/material/Stack";
import TextField from "@mui/material/TextField";
import Typography from "@mui/material/Typography";

export default function ContactUs() {
  return (
    <>
      <Stack
        direction="column"
        spacing={3}
        sx={{
          marginTop: 10,
          alignItems: "center",
        }}
      >
        <Typography
          sx={{
            fontWeight: 550,
            fontSize: { xs: 20, sm: 24 },
          }}
        >
          Contact US
        </Typography>
        <Stack
          direction="column"
          spacing={3}
          sx={{
            paddingInline: {sm:0 ,md:5, lg:10},
            width: "100%",
          }}
        >
          <TextField
            label="Name"
            variant="outlined"
            sx={{
              width: "100%",
            }}
          />
          <TextField
            label="Email"
            variant="outlined"
            sx={{
              width: "100%",
            }}
          />
          <TextField
            label="Message"
            multiline
            rows={3}
            variant="outlined"
            sx={{
              width: "100%",
            }}
          />
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
            Submit
          </Button>
        </Stack>
      </Stack>
    </>
  );
}
