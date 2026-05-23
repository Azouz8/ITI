import Link from "next/link";
import React from "react";
import { getCategories } from "@/services/productApi";
import Category from "@/types/category";

interface Props {
  categories?: Category[];
}

export default async function CategoryList({ categories }: Props) {
  const data = categories || await getCategories();

  return (
    <ul className="flex gap-4 overflow-x-auto pb-4">
      {data.map((category) => (
        <li key={category.slug}>
          <Link
            href={`/category/${category.slug}`}
            className="bg-gray-200 px-4 py-2 whitespace-nowrap hover:bg-blue-600 hover:text-white transition-colors block"
          >
            {category.name}
          </Link>
        </li>
      ))}
    </ul>
  );
}
