import Link from "next/link";

export default function Home() {
  return (
    <div className="mt-12 text-center">
      <h1 className="text-5xl font-bold mb-6">
        Welcome to The Store
      </h1>
      <p className="text-gray-600 text-lg mb-8 max-w-2xl mx-auto">
        Browse our collection of products from various categories. Find
        electronics, jewelry, clothing and more at the best prices.
      </p>
      <div className="flex gap-4 justify-center">
        <Link
          href="/products"
          className="bg-blue-600 text-white px-6 py-3"
        >
          Browse Products
        </Link>
        <Link
          href="/category"
          className="bg-gray-200 text-black px-6 py-3"
        >
          View Categories
        </Link>
      </div>
    </div>
  );
}
