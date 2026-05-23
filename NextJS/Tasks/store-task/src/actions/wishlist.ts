"use server";

import { cookies } from "next/headers";
import { revalidatePath } from "next/cache";

export async function toggleWishlist(productId: number) {
  const cookieStore = await cookies();
  const wishlistCookie = cookieStore.get("wishlist")?.value;
  let wishlist: number[] = wishlistCookie ? JSON.parse(wishlistCookie) : [];

  if (wishlist.includes(productId)) {
    wishlist = wishlist.filter(id => id !== productId);
  } else {
    wishlist.push(productId);
  }

  cookieStore.set("wishlist", JSON.stringify(wishlist), { path: "/" });
  revalidatePath("/products");
  revalidatePath("/");
  
  return wishlist.includes(productId);
}

export async function getWishlist() {
  const cookieStore = await cookies();
  const wishlistCookie = cookieStore.get("wishlist")?.value;
  return wishlistCookie ? (JSON.parse(wishlistCookie) as number[]) : [];
}
