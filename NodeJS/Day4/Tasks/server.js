import express from 'express';
import mongoose from 'mongoose';
import productRoute from './routes/productRoutes.js';
import categoryRoute from './routes/categoryRoute.js';
import 'dotenv/config';
import httpStatus from './utils/httpStatus.js';

const app = express()

app.use(express.json())

app.use("/products", productRoute)
app.use("/categories", categoryRoute)

mongoose.connect(process.env.MongoURL).then(() => {
    console.log("Connected to DB");
}).catch((e) => {
    console.log("Error occured: ", e.message);
})

app.use((req, res, next) => {
    return res.status(404).json({
        status: httpStatus.ERROR,
        message: "Route not found",
    })
})


app.listen(process.env.PORT, () => {
    console.log("server is running on port", process.env.PORT);
})