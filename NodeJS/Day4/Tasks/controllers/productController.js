import Product from '../models/producModel.js';
import asyncWrapper from '../middleware/asyncWrapper.js';
import httpStatus from '../utils/httpStatus.js';
import appError from '../utils/appError.js';

export const getAllProducts = asyncWrapper(
    async (req, res) => {
        const products = await Product.find();
        res.status(200).json({
            status: httpStatus.SUCCESS,
            data: { products }
        })
    }
)

export const getProductById = asyncWrapper(
    async (req, res, next) => {
        const product = await Product.findById(req.params.id);
        if (!product) {
            const error = appError.create("Product not found", 404, httpStatus.FAIL)
            return next(error)
        }
        res.status(200).json({
            status: httpStatus.SUCCESS,
            data: { product }
        })
    }
)


export const addProduct = asyncWrapper(
    async (req, res) => {
        const { name, price, category } = req.body;
        const newProd = new Product({
            name, price, category
        });
        await newProd.save();
        res.status(201).json(
            {
                status: httpStatus.SUCCESS,
                data: { product: newProd },
            }
        )
    }
)

export const updateProduct = asyncWrapper(
    async (req, res, next) => {
        const { id } = req.params
        const updatedProd = await Product.findByIdAndUpdate(id, req.body, { returnDocument: 'after' })
        if (!updatedProd) {
            const error = appError.create("Product not found", 404, httpStatus.FAIL)
            return next(error);
        }
        res.status(200).json({
            status: httpStatus.SUCCESS,
            data: { product: updatedProd },
        })
    }
)

export const deleteProduct = asyncWrapper(
    async (req, res, next) => {
        const { id } = req.params
        const product = await Product.findByIdAndDelete(id)
        if (!product) {
            const error = appError.create("Product not found", 404, httpStatus.FAIL)
            return next(error);
        }
        res.status(200).json({
            status: httpStatus.SUCCESS,
            data: null
        })
    }
)