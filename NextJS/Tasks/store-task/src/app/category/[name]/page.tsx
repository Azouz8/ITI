import { getProductsByCategory } from "@/services/productApi";
import ProductCard from "@/components/ProductCard";
import Product from "@/types/product";

interface Props {
  params: Promise<{
    name: string;
  }>;
}

export async function generateMetadata({ params }: Props) {
  const { name } = await params;
  const decodedName = decodeURIComponent(name);
  return {
    title: `${decodedName.charAt(0).toUpperCase() + decodedName.slice(1)} - Store`,
  };
}

export default async function CategoryDetailPage({ params }: Props) {
  const { name } = await params;
  const decodedName = decodeURIComponent(name);
  const products: Product[] = await getProductsByCategory(decodedName);

  return (
    <div>
      <h1 className="text-3xl font-bold mb-4 capitalize">
        {decodedName}
      </h1>
      <p className="text-gray-600 mb-6">
        Showing {products.length} products
      </p>

      {products.length === 0 ? (
        <p>No products found in this category.</p>
      ) : (
        <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-4">
          {products.map((product: Product) => (
            <ProductCard key={product.id} product={product} />
          ))}
        </div>
      )}
    </div>
  );
}
