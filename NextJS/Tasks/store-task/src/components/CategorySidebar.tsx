"use client";

import Link from "next/link";
import { usePathname } from "next/navigation";
import Category from "@/types/category";

interface Props {
  categories: Category[];
}

export default function CategorySidebar({ categories }: Props) {
  const pathname = usePathname();

  return (
    <nav>
      <ul className="flex flex-col gap-2">
        <li>
          <Link
            href="/category"
            className={`block p-2 ${
              pathname === "/category"
                ? "bg-blue-100 font-bold"
                : "text-blue-600 underline"
            }`}
          >
            All Categories
          </Link>
        </li>
        {categories.map((category) => (
          <li key={category.slug}>
            <Link
              href={`/category/${encodeURIComponent(category.slug)}`}
              className={`block p-2 ${
                decodeURIComponent(pathname) === `/category/${category.slug}`
                  ? "bg-blue-100 font-bold"
                  : "text-blue-600 underline"
              }`}
            >
              {category.name}
            </Link>
          </li>
        ))}
      </ul>
    </nav>
  );
}
