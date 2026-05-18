"use client";

import React from "react";
import Product from "@/types/product";
import { useCart } from "@/context/CartContext";

export default function AddToCartButton({ product }: { product: Product }) {
  const { addToCart } = useCart();

  const handleAdd = (e: React.MouseEvent) => {
    e.preventDefault();
    addToCart(product);
  };

  return (
    <button
      onClick={handleAdd}
      className="bg-green-600 hover:bg-green-700 text-white font-semibold py-2 px-4 rounded w-full transition-colors mt-2"
    >
      Add to Cart
    </button>
  );
}
