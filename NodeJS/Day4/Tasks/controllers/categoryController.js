import asyncWrapper from '../middleware/asyncWrapper.js';
import Category from '../models/categoryModel.js';
import Product from '../models/producModel.js';
import appError from '../utils/appError.js';
import httpStatus from '../utils/httpStatus.js';

export const getAllCategories = asyncWrapper(
    async (req, res) => {
        const categories = await Category.find();
        res.status(200).json({
            status: httpStatus.SUCCESS,
            data: { categories }
        })
    }
)

export const addCategory = asyncWrapper(
    async (req, res, next) => {
        const { name, description } = req.body
        if (!name) {
            const error = appError.create("Name is required", 404, httpStatus.FAIL)
            return next(error);
        }
        const categroy = new Category({
            name, description
        })
        await categroy.save();
        res.status(201).json({
            status: httpStatus.SUCCESS,
            data: { categroy },
        })
    }
)


export const getAllProductsUnderCategory = asyncWrapper(
    async (req, res, next) => {
        const { id } = req.params;
        if (!id) {
            const error = appError.create("CategoryId is required", 404, httpStatus.FAIL)
            return next(error)
        }
        const productsByCategory = await Product.find({ category: id }).populate("category")
        res.status(200).json({
            status: httpStatus.SUCCESS,
            data: {
                products: productsByCategory
            }
        })
    }
)

export const updateCategory = asyncWrapper(
    async (req, res, next) => {
        const { id } = req.params;
        if (!id) {
            const error = appError.create("CategoryId is required", 404, httpStatus.FAIL)
            return next(error)
        }
        const updatedCategory = await Category.findByIdAndUpdate(id, req.body, { returnDocument: 'after' })
        if (!updatedCategory) {
            const error = appError.create("Category not found", 404, httpStatus.FAIL)
            return next(error)
        }
        res.status(200).json({
            status: httpStatus.SUCCESS,
            data: { category: updatedCategory },
        })
    }
)

export const deleteCategory = asyncWrapper(
    async (req, res, next) => {
        const { id } = req.params
        const category = await Category.findByIdAndDelete(id)
        if (!category) {
            const error = appError.create("Category not found", 404, httpStatus.FAIL)
            return next(error)
        }
        res.status(200).json({
            status: httpStatus.SUCCESS,
            data: null
        })
    }
)