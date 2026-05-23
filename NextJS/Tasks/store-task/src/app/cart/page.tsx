"use client";

import React from "react";
import Image from "next/image";
import { useCart } from "@/context/CartContext";
import Link from "next/link";
import { useQuery } from "@tanstack/react-query";
import { calculateTotals } from "@/actions/cart";
import Spinner from "@/components/Spinner";

export default function CartPage() {
  const { cart, removeFromCart, updateQuantity, totalItems } = useCart();

  const { data: totals, isLoading } = useQuery({
    queryKey: ["cartTotals", cart],
    queryFn: () => calculateTotals(cart),
    enabled: cart.length > 0,
  });

  if (cart.length === 0) {
    return (
      <div className="p-6 max-w-5xl mx-auto text-center mt-12">
        <h1 className="text-3xl font-bold mb-4">Your Cart is Empty</h1>
        <p className="text-gray-600 mb-8">Looks like you haven't added anything yet.</p>
        <Link 
          href="/products"
          className="bg-blue-600 text-white px-6 py-3 rounded-md hover:bg-blue-700 transition-colors"
        >
          Continue Shopping
        </Link>
      </div>
    );
  }

  return (
    <div className="p-6 max-w-5xl mx-auto">
      <h1 className="text-3xl font-bold mb-6">Shopping Cart</h1>

      <div className="flex flex-col md:flex-row gap-8">
        <div className="w-full md:w-2/3">
          <ul className="flex flex-col gap-4">
            {cart.map((item) => (
              <li key={item.id} className="flex gap-4 border border-gray-300 p-4 relative">
                <div className="bg-gray-100 p-2 flex-shrink-0 w-24 h-24 flex items-center justify-center">
                  <Image
                    src={item.thumbnail}
                    alt={item.title}
                    width={80}
                    height={80}
                    className="object-contain"
                  />
                </div>
                <div className="flex-1 flex flex-col justify-between">
                  <div className="pr-8">
                    <h3 className="font-bold text-lg">{item.title}</h3>
                    <p className="text-gray-500 text-sm">Price: ${item.price.toFixed(2)}</p>
                  </div>
                  <div className="flex justify-between items-center mt-4">
                    <div className="flex items-center border border-gray-300 rounded">
                      <button 
                        onClick={() => updateQuantity(item.id, item.quantity - 1)}
                        className="px-3 py-1 hover:bg-gray-100"
                      >
                        -
                      </button>
                      <span className="px-4 py-1 border-x border-gray-300 font-semibold">
                        {item.quantity}
                      </span>
                      <button 
                        onClick={() => updateQuantity(item.id, item.quantity + 1)}
                        className="px-3 py-1 hover:bg-gray-100"
                      >
                        +
                      </button>
                    </div>
                    <p className="font-bold text-lg text-green-700">
                      ${(item.price * item.quantity).toFixed(2)}
                    </p>
                  </div>
                </div>
                <button 
                  onClick={() => removeFromCart(item.id)}
                  className="absolute top-4 right-4 text-red-500 hover:text-red-700 text-sm font-bold"
                >
                  ✕
                </button>
              </li>
            ))}
          </ul>
        </div>

        <div className="w-full md:w-1/3 border border-gray-300 p-6 self-start bg-gray-50">
          <h2 className="text-xl font-bold mb-4">Order Summary</h2>
          <div className="flex justify-between mb-2">
            <span className="text-gray-600">Total Items:</span>
            <span className="font-semibold">{totalItems}</span>
          </div>
          
          {isLoading || !totals ? (
            <div className="flex justify-center my-4">
               <Spinner />
            </div>
          ) : (
            <>
              <div className="flex justify-between mb-2">
                <span className="text-gray-600">Subtotal:</span>
                <span className="font-semibold">${totals.subtotal.toFixed(2)}</span>
              </div>
              <div className="flex justify-between mb-2">
                <span className="text-gray-600">Tax (10%):</span>
                <span className="font-semibold">${totals.tax.toFixed(2)}</span>
              </div>
              <div className="flex justify-between mb-4 border-b border-gray-300 pb-4">
                <span className="text-gray-600">Shipping:</span>
                <span className="font-semibold">
                  {totals.shipping === 0 ? <span className="text-green-600 font-bold">Free</span> : `$${totals.shipping.toFixed(2)}`}
                </span>
              </div>
              <div className="flex justify-between text-xl font-bold">
                <span>Total:</span>
                <span className="text-green-700">${totals.total.toFixed(2)}</span>
              </div>
            </>
          )}

          <Link href="/checkout" className="w-full block text-center bg-blue-600 text-white py-3 mt-6 hover:bg-blue-700 transition-colors font-semibold rounded">
            Proceed to Checkout
          </Link>
        </div>
      </div>
    </div>
  );
}
