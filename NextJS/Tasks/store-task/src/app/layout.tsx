import "./globals.css";
import { Josefin_Sans } from "next/font/google";
import Header from "@/components/Header";
import { CartProvider } from "@/context/CartContext";
import ReactQueryProvider from "@/providers/ReactQueryProvider";
import { SessionProvider } from "next-auth/react";

export const metadata = {
  title: "Store",
  description: "A Next.js store app using DummyJSON API",
};

const josefin = Josefin_Sans({ subsets: ["latin"] });

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body className={josefin.className + " min-h-screen flex flex-col bg-white text-black"}>
        <SessionProvider>
          <ReactQueryProvider>
            <CartProvider>
              <Header />
              <div className="flex-1">
                <main className="w-full h-full">{children}</main>
              </div>
            </CartProvider>
          </ReactQueryProvider>
        </SessionProvider>
      </body>
    </html>
  );
}
