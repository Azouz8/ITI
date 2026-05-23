"use client";

import Link from "next/link";
import { usePathname } from "next/navigation";
import React from "react";
import { useCart } from "@/context/CartContext";
import { useSession, signOut } from "next-auth/react";

const navItems = [
  { name: "Home", path: "/" },
  { name: "Products", path: "/products" },
  { name: "Categories", path: "/category" },
];

export default function Navigation() {
  const pathname = usePathname();
  const { totalItems } = useCart();
  const { data: session, status } = useSession();

  return (
    <nav>
      <ul className="flex gap-6 items-center">
        {navItems.map((item) => (
          <li key={item.path}>
            <Link
              href={item.path}
              className={`font-semibold hover:text-blue-600 transition-colors ${
                pathname === item.path ? "text-blue-600" : "text-gray-600"
              }`}
            >
              {item.name}
            </Link>
          </li>
        ))}
        <li>
          <Link
            href="/cart"
            className={`font-semibold hover:text-blue-600 transition-colors flex items-center gap-1 ${
              pathname === "/cart" ? "text-blue-600" : "text-gray-600"
            }`}
          >
            Cart
            {totalItems > 0 && (
              <span className="bg-blue-600 text-white text-xs font-bold px-2 py-0.5 rounded-full">
                {totalItems}
              </span>
            )}
          </Link>
        </li>
        
        {/* Auth Section */}
        {status === "loading" ? null : session ? (
          <>
            <li>
              <Link href="/profile" className="font-semibold text-gray-600 hover:text-blue-600">
                Profile
              </Link>
            </li>
            <li>
              <button 
                onClick={() => signOut()} 
                className="font-semibold text-red-500 hover:text-red-700 transition-colors"
              >
                Sign Out
              </button>
            </li>
          </>
        ) : (
          <li>
            <Link href="/login" className="font-semibold text-blue-600 hover:text-blue-800">
              Login
            </Link>
          </li>
        )}
      </ul>
    </nav>
  );
}
