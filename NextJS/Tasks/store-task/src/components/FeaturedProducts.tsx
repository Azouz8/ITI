"use client";

import { useQuery } from "@tanstack/react-query";
import Product from "@/types/product";
import ProductCard from "./ProductCard";
import Spinner from "./Spinner";

interface Props {
  initialProducts: Product[];
  initialWishlist: number[];
}

export default function FeaturedProducts({ initialProducts, initialWishlist }: Props) {
  const { data: products, isLoading, isError, error } = useQuery({
    queryKey: ["featuredProducts"],
    queryFn: async () => {
      const res = await fetch("https://dummyjson.com/products?limit=8");
      if (!res.ok) throw new Error("Failed to fetch featured products");
      const data = await res.json();
      return data.products as Product[];
    },
    initialData: initialProducts,
  });

  if (isLoading) return <Spinner />;
  if (isError) return <div className="text-red-500">Error: {error.message}</div>;

  return (
    <div className="grid grid-cols-1 sm:grid-cols-2 md:grid-cols-4 gap-4">
      {products.map((product) => (
        <ProductCard 
          key={product.id} 
          product={product} 
          inWishlist={initialWishlist.includes(product.id)}
        />
      ))}
    </div>
  );
}
