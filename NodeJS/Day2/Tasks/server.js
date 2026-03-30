import express from "express";
import fs from "fs/promises";

const app = express();
app.use(express.json());

const read = async () => {
  const data = await fs.readFile("product.json", "utf-8");
  return JSON.parse(data);
};

const write = async (products) => {
  await fs.writeFile("product.json", JSON.stringify(products));
};

app.get("/products", async (req, res) => {
  try {
    const products = await read();
    res.status(200).json({
      data: products,
    });
  } catch (error) {
    return res.status(500).json({
      message: error.message,
    });
  }
});

const createProduct = (name, price) => {
  return {
    id: Date.now(),
    name,
    price,
  };
};

app.post("/products", async (req, res) => {
  try {
    const { name, price } = req.body;
    if (!name || !price) {
      return res.status(400).json({
        message: "Name and Price are required",
      });
    }
    const newProd = createProduct(name, price);
    const products = await read();
    products.push(newProd);
    await write(products);
    return res.status(200).json({
      message: "Product added successfully",
      data: newProd,
    });
  } catch (error) {
    return res.status(500).json({
      message: error.message,
    });
  }
});

app.put("/products/:id", async (req, res) => {
  try {
    const updatedProd = req.body;
    updatedProd.id = Number(req.params.id);
    const { id } = req.params;
    if (!id || !updatedProd) {
      return res.status(400).json({
        message: "ID and The New Updated Product are Required",
      });
    }
    const products = await read();
    const index = products.findIndex((p) => p.id == id);
    if (index != -1) {
      products[index] = updatedProd;
      await write(products);
      return res.status(200).json({
        message: "Product updated successfully",
        data: updatedProd,
      });
    } else {
      return res.status(404).json({
        message: "Product not found",
      });
    }
  } catch (error) {
    return res.status(500).json({
      message: error.message,
    });
  }
});

app.delete("/products", async (req, res) => {
  try {
    const { id } = req.body;
    if (!id) {
      return res.status(400).json({
        message: "ID is Required",
      });
    }
    const products = await read();
    const index = products.findIndex((p) => p.id == id);
    if (index != -1) {
      products.splice(index, 1);
      await write(products);
      return res.status(200).json({
        message: "Product deleted successfully",
      });
    } else {
      return res.status(404).json({
        message: "Product not found",
      });
    }
  } catch (error) {
    return res.status(500).json({
      message: error.message,
    });
  }
});

app.listen(5000, () => {
  console.log("server is running");
});
