import CategoryList from "@/components/CategoryList";
import React, { Suspense } from "react";
import Spinner from "@/components/Spinner";

export const dynamic = "force-dynamic";

export const metadata = {
  title: "Categories - Store",
  description: "Browse products by category",
};

export default function CategoryPage() {
  return (
    <div>
      <h1 className="text-3xl font-bold mb-4">
        Product Categories
      </h1>
      <p className="text-gray-600 mb-8">
        Choose a category from the sidebar or below to browse products.
      </p>

      <Suspense fallback={<Spinner />}>
        <CategoryList />
      </Suspense>
    </div>
  );
}
