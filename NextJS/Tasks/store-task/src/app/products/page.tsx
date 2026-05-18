import ProductList from "@/components/ProductList";
import React, { Suspense } from "react";
import Spinner from "@/components/Spinner";

export const dynamic = "force-dynamic";

export const metadata = {
  title: "Products - Store",
  description: "Browse all products available in Store",
};

interface Props {
  searchParams: Promise<{ [key: string]: string | string[] | undefined }>;
}

export default async function ProductsPage({ searchParams }: Props) {
  const resolvedSearchParams = await searchParams;
  const q = typeof resolvedSearchParams.q === "string" ? resolvedSearchParams.q : "";

  return (
    <div className="p-6 max-w-5xl mx-auto">
      <h1 className="text-3xl font-bold mb-4">
        {q ? `Search Results for "${q}"` : "All Products"}
      </h1>
      <p className="text-gray-600 mb-8">
        {q ? `Showing results matching your query.` : `Explore our wide range of products from different categories.`}
      </p>

      <Suspense fallback={<Spinner />} key={q}>
        <ProductList query={q} />
      </Suspense>
    </div>
  );
}
