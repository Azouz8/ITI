import Category from '../models/categoryModel.js';
import Product from '../models/producModel.js';
import httpStatus from '../utils/httpStatus.js';

export const getAllCategories = async (req, res) => {
    try {
        const categories = await Category.find();
        res.status(200).json({
            status: httpStatus.SUCCESS,
            data: { categories }
        })
    } catch (error) {
        res.status(500).json({
            message: error.message,
        });
    }
}

export const addCategory = async (req, res) => {
    try {
        const { name, description } = req.body
        if (!name) {
            return res.status(404).json({
                status: httpStatus.FAIL,
                message: "name is required"
            })
        }
        const categroy = new Category({
            name, description
        })
        await categroy.save();
        res.status(201).json({
            status: httpStatus.SUCCESS,
            data: { categroy },
        })
    } catch (error) {
        res.status(500).json({
            message: error.message,
        });
    }
}


export const getAllProductsUnderCategory = async (req, res) => {
    try {
        const { id } = req.params;
        if (!id) {
            return res.status(404).json({
                status: httpStatus.FAIL,
                message: "categoryId is required"
            })
        }
        const productsByCategory = await Product.find({ category: id }).populate("category")
        res.status(200).json({
            status: httpStatus.SUCCESS,
            data: {
                products: productsByCategory
            }
        })
    } catch (error) {
        res.status(500).json({
            message: error.message,
        });
    }
}

export const updateCategory = async (req, res) => {
    try {
        const { id } = req.params;
        if (!id) {
            return res.status(404).json({
                status: httpStatus.FAIL,
                message: "categoryId is required"
            })
        }
        const updatedCategory = await Category.findByIdAndUpdate(id, req.body, { returnDocument: 'after' })
        if (!updatedCategory) {
            return res.status(404).json({
                status: httpStatus.FAIL,
                message: "Category not found"
            })
        }
        res.status(200).json({
            status: httpStatus.SUCCESS,
            data: { category: updatedCategory },
        })
    } catch (error) {
        res.status(500).json({
            message: error.message,
        });
    }
}

export const deleteCategory = async (req, res) => {
    try {
        const { id } = req.params
        const category = await Category.findByIdAndDelete(id)
        if (!category)
            return res.status(404).json({
                status: httpStatus.FAIL,
                message: "Category not found"
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