import Link from "next/link";

export default function NotFound() {
  return (
    <div className="flex flex-col items-center justify-center min-h-[60vh] text-center px-4">
      <h2 className="text-6xl font-bold text-gray-800 mb-4">404</h2>
      <h3 className="text-2xl font-semibold text-gray-600 mb-6">Product Not Found</h3>
      <p className="text-gray-500 mb-8 max-w-md">
        We couldn&apos;t find the page or product you were looking for. It might have been removed or doesn&apos;t exist.
      </p>
      <Link 
        href="/products" 
        className="bg-blue-600 text-white px-6 py-3 rounded hover:bg-blue-700 transition-colors"
      >
        Return to Products
      </Link>
    </div>
  );
}
