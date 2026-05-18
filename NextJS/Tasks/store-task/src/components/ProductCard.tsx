import Product from "@/types/product";
import Image from "next/image";
import Link from "next/link";
import AddToCartButton from "./AddToCartButton";

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
        <div className="flex gap-2 flex-col mt-3">
          <Link
            href={`/products/${product.id}`}
            className="bg-blue-600 text-white text-center py-2 px-4 rounded hover:bg-blue-700 transition-colors"
          >
            View Product
          </Link>
          <AddToCartButton product={product} />
        </div>
      </div>
    </div>
  );
}
