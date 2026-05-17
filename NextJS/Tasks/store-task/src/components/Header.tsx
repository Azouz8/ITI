import Logo from "./Logo";
import Navigation from "./Navigation";

export default function Header() {
  return (
    <header className="border-b border-gray-300 px-6 py-4 bg-gray-50">
      <div className="flex justify-between items-center">
        <Logo />
        <Navigation />
      </div>
    </header>
  );
}
