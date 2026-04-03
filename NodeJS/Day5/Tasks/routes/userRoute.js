import express from 'express';
import {
    getAllUsers,
    loginUser,
    registerUser
} from '../controllers/userController.js';
import verifyToken from '../middleware/verifyToken.js';
import authorize from '../middleware/authorize.js';
import fileUploader from '../utils/fileUploader.js';


const router = express.Router();

router.get("/", verifyToken, authorize("admin"), getAllUsers)
router.post("/login", loginUser)
router.post("/register", fileUploader.single("avatar"), registerUser)


export default router;