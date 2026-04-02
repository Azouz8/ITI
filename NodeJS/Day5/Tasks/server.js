import express from 'express';
import mongoose from 'mongoose';
import productRoute from './routes/productRoutes.js';
import categoryRoute from './routes/categoryRoute.js';
import userRoute from './routes/userRoute.js';
import httpStatus from './utils/httpStatus.js';
import 'dotenv/config';

const app = express()

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