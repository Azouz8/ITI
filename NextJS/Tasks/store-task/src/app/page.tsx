import { getProducts, getCategories } from "@/services/productApi";
import CategoryList from "@/components/CategoryList";
import FeaturedProducts from "@/components/FeaturedProducts";
import { getWishlist } from "@/actions/wishlist";

export default async function HomePage() {
  const products = await getProducts();
  const categories = await getCategories();
  const wishlist = await getWishlist();

  return (
    <div className="p-6 max-w-5xl mx-auto">
      <h1 className="text-4xl font-bold mb-8 text-center mt-10">Welcome to Store</h1>
      
      <section className="mb-12">
        <h2 className="text-2xl font-bold mb-6 border-b pb-2">Shop by Category</h2>
        <CategoryList categories={categories} />
      </section>

      <section>
        <h2 className="text-2xl font-bold mb-6 border-b pb-2">Featured Products</h2>
        <FeaturedProducts 
          initialProducts={products.slice(0, 8)} 
          initialWishlist={wishlist}
        />
      </section>
    </div>
  );
}
