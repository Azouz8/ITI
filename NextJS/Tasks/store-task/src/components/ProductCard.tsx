import Product from "@/types/product";
import Image from "next/image";
import Link from "next/link";
import React from "react";

interface Props {
  product: Product;
}

export default function ProductCard({ product }: Props) {
  return (
    <div className="border border-gray-300 p-4 flex flex-col">
      <div className="relative h-48 flex items-center justify-center bg-gray-100 mb-4">
        <Image
          src={product.thumbnail}
          alt={product.title}
          width={150}
          height={150}
          className="object-contain h-40 w-auto"
        />
      </div>

      <div className="flex flex-col flex-1">
        <h2 className="text-lg font-bold mb-1">
          {product.title}
        </h2>
        <p className="text-gray-500 text-sm mb-2">
          {product.category}
        </p>
        <p className="text-xl font-bold mt-auto mb-2">
          ${product.price.toFixed(2)}
        </p>
        <div className="text-sm mb-3">
          Rating: {product.rating} / 5
        </div>
        <Link
          href={`/products/${product.id}`}
          className="bg-blue-600 text-white text-center py-2 px-4 inline-block"
        >
          View Product
        </Link>
      </div>
    </div>
  );
}
