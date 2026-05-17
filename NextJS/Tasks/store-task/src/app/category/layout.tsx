import CategorySidebar from "@/components/CategorySidebar";
import { getCategories } from "@/services/productApi";
import React from "react";

export default async function CategoryLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  const categories = await getCategories();

  return (
    <div className="flex flex-col md:flex-row items-start min-h-[calc(100vh-73px)]">
      <div className="w-full md:w-64 flex-shrink-0 p-6 border-r border-gray-300 min-h-full">
        <CategorySidebar categories={categories} />
      </div>
      <div className="flex-1 p-6 flex justify-center">
        <div className="w-full max-w-4xl">
          {children}
        </div>
      </div>
    </div>
  );
}
