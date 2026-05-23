"use client";

import { toggleWishlist } from "@/actions/wishlist";
import { useState } from "react";

export default function WishlistButton({
  productId,
  initialInWishlist,
}: {
  productId: number;
  initialInWishlist: boolean;
}) {
  const [inWishlist, setInWishlist] = useState(initialInWishlist);

  const handleToggle = async () => {
    setInWishlist(!inWishlist);
    const newState = await toggleWishlist(productId);
    setInWishlist(newState);
  };

  return (
    <button
      onClick={handleToggle}
      className={`absolute top-2 right-2 p-2 rounded-full border transition-colors ${
        inWishlist
          ? "bg-red-500 text-white border-red-500"
          : "bg-white text-gray-400 border-gray-300 hover:text-red-500"
      }`}
      aria-label="Toggle Wishlist"
    >
      ♥
    </button>
  );
}
