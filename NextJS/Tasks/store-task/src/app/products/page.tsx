import ProductList from "@/components/ProductList";
import React, { Suspense } from "react";
import Spinner from "@/components/Spinner";

export const dynamic = "force-dynamic";

export const metadata = {
  title: "Products - Store",
  description: "Browse all products available in Store",
};

export default function ProductsPage() {
  return (
    <div className="p-6 max-w-5xl mx-auto">
      <h1 className="text-3xl font-bold mb-4">
        All Products
      </h1>
      <p className="text-gray-600 mb-8">
        Explore our wide range of products from different categories.
      </p>

      <Suspense fallback={<Spinner />}>
        <ProductList />
      </Suspense>
    </div>
  );
}
