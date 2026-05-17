import { getProducts } from "@/services/productApi";
import Product from "@/types/product";
import React from "react";
import ProductCard from "./ProductCard";

export default async function ProductList() {
  const products: Product[] = await getProducts();

  if (products.length === 0) {
    return (
      <div>
        <h1 className="text-2xl font-bold">
          No Products Available
        </h1>
      </div>
    );
  }

  return (
    <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
      {products.map((product: Product) => (
        <ProductCard key={product.id} product={product} />
      ))}
    </div>
  );
}
