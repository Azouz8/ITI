import express from "express";
const app = express();

app.get("/", function (req, res) {
    res.status(200).send("hello world");
});

app.get("/status", function (req, res) {
    res.status(200).json({ status: "ok" });
});

export default app;