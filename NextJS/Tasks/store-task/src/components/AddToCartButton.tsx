"use client";

import React, { useState } from "react";
import Product from "@/types/product";
import { useCart } from "@/context/CartContext";

export default function AddToCartButton({ product }: { product: Product }) {
  const { addToCart, updateQuantity, cart } = useCart();
  const [quantity, setQuantity] = useState(1);

  const cartItem = cart.find((item) => item.id === product.id);

  const handleAdd = (e: React.MouseEvent) => {
    e.preventDefault();
    if (cartItem) {
      updateQuantity(product.id, cartItem.quantity + quantity);
    } else {
      for (let i = 0; i < quantity; i++) {
        addToCart(product);
      }
    }
  };

  return (
    <div className="flex flex-col gap-2 mt-2 w-full">
      <div className="flex items-center justify-between border border-gray-300 rounded px-2">
        <span className="text-gray-600 text-sm">Qty:</span>
        <div className="flex items-center">
          <button
            onClick={(e) => {
              e.preventDefault();
              setQuantity(Math.max(1, quantity - 1));
            }}
            className="px-3 py-1 hover:bg-gray-100 text-lg"
          >
            -
          </button>
          <span className="px-3 py-1 font-semibold border-x border-gray-200">
            {quantity}
          </span>
          <button
            onClick={(e) => {
              e.preventDefault();
              setQuantity(quantity + 1);
            }}
            className="px-3 py-1 hover:bg-gray-100 text-lg"
          >
            +
          </button>
        </div>
      </div>
      <button
        onClick={handleAdd}
        className="bg-green-600 hover:bg-green-700 text-white font-semibold py-2 px-4 rounded w-full transition-colors"
      >
        Add to Cart
      </button>
    </div>
  );
}
