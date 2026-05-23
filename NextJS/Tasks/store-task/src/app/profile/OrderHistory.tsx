import Cart from "@/types/cart";
import React from "react";

export default async function OrderHistory({ userId }: { userId: string }) {
  const res = await fetch(`https://dummyjson.com/carts/user/${userId}`, {
    cache: "no-store",
  });
  
  if (!res.ok) {
    return <p className="text-red-500">Failed to load order history.</p>;
  }

  const data = await res.json();
  const orders: Cart[] = data.carts;

  if (!orders || orders.length === 0) {
    return <p className="text-gray-500">You haven't placed any orders yet.</p>;
  }

  return (
    <div className="flex flex-col gap-4">
      {orders.map((order) => (
        <div key={order.id} className="border border-gray-200 rounded p-4 bg-white">
          <div className="flex justify-between border-b border-gray-100 pb-2 mb-2">
            <div>
              <span className="font-semibold text-gray-700">Order #{order.id}</span>
              <span className="text-sm text-gray-500 ml-4">{order.totalQuantity} items</span>
            </div>
            <span className="font-bold text-green-700">${order.discountedTotal.toFixed(2)}</span>
          </div>
          <ul className="text-sm text-gray-600 flex flex-col gap-1">
            {order.products.slice(0, 3).map((product) => (
              <li key={product.id}>
                {product.quantity}x {product.title}
              </li>
            ))}
            {order.products.length > 3 && (
              <li className="italic text-gray-400">...and {order.products.length - 3} more items</li>
            )}
          </ul>
        </div>
      ))}
    </div>
  );
}
