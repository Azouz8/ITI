import { getProducts, searchProducts } from "@/services/productApi";
import Product from "@/types/product";
import React from "react";
import ProductCard from "./ProductCard";
import { getWishlist } from "@/actions/wishlist";

interface Props {
  query?: string;
}

export default async function ProductList({ query }: Props) {
  const products: Product[] = query ? await searchProducts(query) : await getProducts();
  const wishlist = await getWishlist();

  if (products.length === 0) {
    return (
      <div>
        <h1 className="text-2xl font-bold">
          No Products Found
        </h1>
      </div>
    );
  }

  return (
    <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
      {products.map((product: Product) => (
        <ProductCard 
          key={product.id} 
          product={product} 
          inWishlist={wishlist.includes(product.id)} 
        />
      ))}
    </div>
  );
}
