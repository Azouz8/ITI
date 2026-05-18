import { notFound } from "next/navigation";
import Product from "@/types/product";
import Category from "@/types/category";

const BASE_URL = "https://dummyjson.com";

export async function getProducts(): Promise<Product[]> {
  const res = await fetch(`${BASE_URL}/products?limit=20`);

  if (!res.ok) {
    throw new Error("Products could not be loaded");
  }

  const data = await res.json();
  return data.products;
}

export async function getProduct(id: number): Promise<Product> {
  const res = await fetch(`${BASE_URL}/products/${id}`);

  if (!res.ok) {
    notFound();
  }

  return res.json();
}

export async function getCategories(): Promise<Category[]> {
  const res = await fetch(`${BASE_URL}/products/categories`);

  if (!res.ok) {
    throw new Error("Categories could not be loaded");
  }

  return res.json();
}

export async function getProductsByCategory(
  category: string
): Promise<Product[]> {
  const res = await fetch(
    `${BASE_URL}/products/category/${encodeURIComponent(category)}`
  );

  if (!res.ok) {
    throw new Error(`Products for category "${category}" could not be loaded`);
  }

  const data = await res.json();
  return data.products;
}

export async function searchProducts(query: string): Promise<Product[]> {
  const res = await fetch(
    `${BASE_URL}/products/search?q=${encodeURIComponent(query)}`
  );

  if (!res.ok) {
    throw new Error(`Failed to search products for "${query}"`);
  }

  const data = await res.json();
  return data.products;
}
