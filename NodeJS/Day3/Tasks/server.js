import express from 'express';
import mongoose from 'mongoose';
import productRoute from './routes/productRoutes.js';

const app = express()

app.use(express.json())

app.use("/products", productRoute)

mongoose.connect('mongodb://localhost:27017/productsDB').then(() => {
    console.log("Connected to DB");
}).catch((e) => {
    console.log("Error occured: ", e);
})

app.listen(5000, () => {
    console.log("server is running on port 3000");
})