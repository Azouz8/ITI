import Link from "next/link";
import { getCategories } from "@/services/productApi";
import Category from "@/types/category";

export default async function CategoryList() {
  const categories: Category[] = await getCategories();

  return (
    <div className="grid grid-cols-2 md:grid-cols-3 gap-4">
      {categories.map((category) => (
        <Link
          key={category.slug}
          href={`/category/${encodeURIComponent(category.slug)}`}
          className="border border-gray-300 p-4 text-center bg-gray-50"
        >
          <h2 className="text-lg font-bold">
            {category.name}
          </h2>
        </Link>
      ))}
    </div>
  );
}
