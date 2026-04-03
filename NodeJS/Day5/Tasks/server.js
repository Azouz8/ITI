import express from 'express';
import mongoose from 'mongoose';
import userRoute from './routes/userRoute.js';
import httpStatus from './utils/httpStatus.js';
import 'dotenv/config';
import path from 'path';
import { fileURLToPath } from 'url';
const __filename = fileURLToPath(import.meta.url);
const __dirname = path.dirname(__filename);

const app = express()

app.use("/uploads", express.static(path.join(__dirname, "uploads")))
app.use(express.json())

app.use("/users", userRoute)

mongoose.connect(process.env.MongoURL).then(() => {
    console.log("Connected to DB");
}).catch((e) => {
    console.log("Error occured: ", e.message);
})

app.use((err, req, res, next) => {
    res.status(err.statusCode || 500).json({
        status: err.status || httpStatus.ERROR,
        message: err.message || 'Internal Server Error',
        code: err.statusCode
    });
});

app.use((req, res, next) => {
    return res.status(404).json({
        status: httpStatus.ERROR,
        message: "Route not found",
    })
})


app.listen(process.env.PORT, () => {
    console.log("server is running on port", process.env.PORT);
})