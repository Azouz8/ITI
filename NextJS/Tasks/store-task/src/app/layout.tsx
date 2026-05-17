import "./globals.css";
import { Josefin_Sans } from "next/font/google";
import Header from "@/components/Header";

export const metadata = {
  title: "Store - Next.js",
  description: "A Next.js store app",
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
        <Header />
        <div className="flex-1">
          <main className="w-full h-full">{children}</main>
        </div>
      </body>
    </html>
  );
}
