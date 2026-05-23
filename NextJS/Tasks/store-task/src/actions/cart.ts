"use server";
import { CartItem } from "@/context/CartContext";

export async function calculateTotals(items: CartItem[]) {
  await new Promise(res => setTimeout(res, 500));

  const subtotal = items.reduce((acc, item) => acc + item.price * item.quantity, 0);
  const shipping = subtotal > 200 ? 0 : 25; 
  const tax = subtotal * 0.1; 
  const total = subtotal + shipping + tax;

  return {
    subtotal,
    shipping,
    tax,
    total,
  };
}
