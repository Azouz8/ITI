import mongoose from 'mongoose';

const { Schema } = mongoose;

const productSchema = new Schema(
    {
        name: {
            type: String,
            required: true,
        },
        price: {
            type: Number,
            required: true,
        },
        category: {
            type: Schema.Types.ObjectId,
            ref: 'category',
            required: true,
        },

    },
    {
        timestamps: true
    }
)

const productModel = mongoose.model("product", productSchema)

export default productModel;