import Link from "next/link";

export default function NotFound() {
  return (
    <div className="text-center mt-24">
      <h1 className="text-6xl font-bold text-teal-400 mb-4">404</h1>
      <p className="text-gray-400 text-xl mb-8">
        The page you are looking for does not exist.
      </p>
      <Link
        href="/"
        className="bg-teal-500 px-6 py-3 text-white rounded-full hover:bg-teal-600 transition-colors font-semibold"
      >
        Go Home
      </Link>
    </div>
  );
}
