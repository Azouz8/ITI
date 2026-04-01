import express from 'express';
import { getAllCategories, addCategory, getAllProductsUnderCategory, updateCategory, deleteCategory } from '../controllers/categoryController.js';

const router = express.Router()

router.get("/", getAllCategories)
router.get("/products/:id", getAllProductsUnderCategory)
router.post("/", addCategory)
router.post("/:id", updateCategory)
router.delete("/:id", deleteCategory)

export default router;