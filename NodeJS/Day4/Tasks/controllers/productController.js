import Product from '../models/producModel.js';
import httpStatus from '../utils/httpStatus.js';

export const getAllProducts = async (req, res) => {
    try {
        const products = await Product.find();
        res.status(200).json({
            status: httpStatus.SUCCESS,
            data: { products }
        })
    } catch (error) {
        res.status(500).json({
            message: error.message,
        });
    }
}

export const getProductById = async (req, res) => {
    try {
        const product = await Product.findById(req.params.id);
        if (!product)
            return res.status(404).json({
                status: httpStatus.FAIL,
                message: "Product not found"
            })

        res.status(200).json({
            status: httpStatus.SUCCESS,
            data: { product }
        })
    } catch (error) {
        res.status(500).json({
            message: error.message,
        });
    }
}

export const addProduct = async (req, res) => {
    try {
        const { name, price, category } = req.body;
        const newProd = new Product({
            name, price, category
        });
        await newProd.save();
        res.status(201).json({
            status: httpStatus.SUCCESS,
            data: { product: newProd },
        })
    } catch (error) {
        res.status(500).json({
            message: error.message,
        });
    }
}

export const updateProduct = async (req, res) => {
    try {
        const { id } = req.params
        const updatedProd = await Product.findByIdAndUpdate(id, req.body, { returnDocument: 'after' })
        if (!updatedProd)
            return res.status(404).json({
                status: httpStatus.FAIL,
                message: "Product not found"
            })
        res.status(200).json({
            status: httpStatus.SUCCESS,
            data: { product: updatedProd },
        })
    } catch (error) {
        res.status(500).json({
            message: error.message,
        });
    }
}

export const deleteProduct = async (req, res) => {
    try {
        const { id } = req.params
        const product = await Product.findByIdAndDelete(id)
        if (!product)
            return res.status(404).json({
                status: httpStatus.FAIL,
                message: "Product not found"
            })
        res.status(200).json({
            status: httpStatus.SUCCESS,
            data: null
        })
    } catch (error) {
        res.status(500).json({
            message: error.message,
        });
    }
}