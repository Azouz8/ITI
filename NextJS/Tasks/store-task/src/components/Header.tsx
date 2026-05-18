import Logo from "./Logo";
import Navigation from "./Navigation";
import SearchBar from "./SearchBar";

export default function Header() {
  return (
    <header className="border-b border-gray-300 px-6 py-4 bg-gray-50">
      <div className="flex justify-between items-center gap-6">
        <Logo />
        <div className="flex-1 flex justify-center max-w-md hidden md:flex">
          <SearchBar />
        </div>
        <Navigation />
      </div>
    </header>
  );
}
