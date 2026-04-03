import multer from 'multer';
import appError from '../utils/appError.js';
import httpStatus from '../utils/httpStatus.js';

const diskStorage = multer.diskStorage({
    destination: function (req, file, cb) {
        cb(null, "uploads")
    },
    filename: function (req, file, cb) {
        const ext = file.mimetype.split("/")[1];
        const fileName = `${Date.now()}-avatar.${ext}`
        cb(null, fileName)
    }
})
const fileFilter = (req, file, cb) => {
    const fileType = file.mimetype.split("/")[0]
    if (fileType === 'image') {
        return cb(null, true)
    }
    else {
        const error = appError.create("Invalid File Type", 400, httpStatus.ERROR)
        return cb(error, false)
    }
}
const upload = multer({
    storage: diskStorage,
    fileFilter
})

export default upload;

