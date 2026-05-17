import { getProduct } from "@/services/productApi";
import Image from "next/image";
import Link from "next/link";
import React from "react";

interface Props {
  params: Promise<{
    id: string;
  }>;
}

export async function generateMetadata({ params }: Props) {
  const { id } = await params;
  const product = await getProduct(Number(id));
  return {
    title: `${product.title} - Store`,
  };
}

export default async function ProductDetailPage({ params }: Props) {
  const { id } = await params;
  const product = await getProduct(Number(id));

  return (
    <div className="p-6 max-w-5xl mx-auto">
      <Link
        href="/products"
        className="text-blue-600 underline mb-4 inline-block"
      >
        ← Back to Products
      </Link>

      <div className="flex flex-col md:flex-row gap-8 mt-4">
        <div className="w-full md:w-1/2 flex justify-center bg-gray-100 p-4 border border-gray-300">
          <Image
            src={product.thumbnail}
            alt={product.title}
            width={400}
            height={400}
            className="object-contain"
          />
        </div>

        <div className="w-full md:w-1/2">
          <p className="text-gray-500 uppercase tracking-widest mb-2 text-sm">
            {product.category}
          </p>
          <h1 className="text-2xl font-bold mb-4">
            {product.title}
          </h1>
          <p className="text-3xl font-bold text-green-700 mb-6">
            ${product.price.toFixed(2)}
          </p>
          <p className="text-gray-700 mb-6">
            {product.description}
          </p>
          <div className="text-gray-600">
            Rating: {product.rating} / 5
          </div>
        </div>
      </div>
    </div>
  );
}
