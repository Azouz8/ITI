"use client";

import { useRouter } from "next/navigation";
import { useState } from "react";

export default function SearchBar() {
  const [query, setQuery] = useState("");
  const router = useRouter();

  const handleSearch = (e: React.FormEvent) => {
    e.preventDefault();
    if (query.trim()) {
      router.push(`/products?q=${encodeURIComponent(query.trim())}`);
    } else {
      router.push(`/products`);
    }
  };

  return (
    <form onSubmit={handleSearch} className="flex gap-2">
      <input
        type="text"
        placeholder="Search products..."
        value={query}
        onChange={(e) => setQuery(e.target.value)}
        className="border border-gray-300 px-3 py-1 text-sm focus:outline-none focus:border-blue-500"
      />
      <button
        type="submit"
        className="bg-blue-600 text-white px-3 py-1 text-sm hover:bg-blue-700"
      >
        Search
      </button>
    </form>
  );
}
