"use client";

import { useState } from "react";
import { useRouter } from "next/navigation";
import Link from "next/link";

export default function RegisterPage() {
  const [firstName, setFirstName] = useState("");
  const [lastName, setLastName] = useState("");
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");
  const [success, setSuccess] = useState(false);
  const router = useRouter();

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError("");

    try {
      const res = await fetch("https://dummyjson.com/users/add", {
        method: "POST",
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify({
          firstName,
          lastName,
          username,
          password,
        }),
      });

      if (res.ok) {
        setSuccess(true);
        setTimeout(() => {
          router.push("/login");
        }, 2000);
      } else {
        setError("Registration failed. Please try again.");
      }
    } catch (err) {
      setError("An error occurred during registration.");
    }
  };

  return (
    <div className="flex justify-center items-center min-h-[70vh]">
      <div className="bg-white p-8 border border-gray-300 rounded shadow-sm w-full max-w-md">
        <h1 className="text-2xl font-bold mb-6 text-center">Create an Account</h1>
        
        {error && (
          <div className="bg-red-50 text-red-600 p-3 mb-4 rounded border border-red-200">
            {error}
          </div>
        )}
        
        {success ? (
          <div className="bg-green-50 text-green-700 p-4 rounded border border-green-200 text-center">
            Registration successful! Redirecting to login...
          </div>
        ) : (
          <form onSubmit={handleSubmit} className="flex flex-col gap-4">
            <div className="flex gap-4">
              <div className="flex-1">
                <label className="block text-gray-700 font-semibold mb-2">First Name</label>
                <input
                  type="text"
                  value={firstName}
                  onChange={(e) => setFirstName(e.target.value)}
                  className="w-full border border-gray-300 p-2 rounded focus:outline-none focus:border-blue-500"
                  required
                />
              </div>
              <div className="flex-1">
                <label className="block text-gray-700 font-semibold mb-2">Last Name</label>
                <input
                  type="text"
                  value={lastName}
                  onChange={(e) => setLastName(e.target.value)}
                  className="w-full border border-gray-300 p-2 rounded focus:outline-none focus:border-blue-500"
                  required
                />
              </div>
            </div>
            <div>
              <label className="block text-gray-700 font-semibold mb-2">Username</label>
              <input
                type="text"
                value={username}
                onChange={(e) => setUsername(e.target.value)}
                className="w-full border border-gray-300 p-2 rounded focus:outline-none focus:border-blue-500"
                required
              />
            </div>
            <div>
              <label className="block text-gray-700 font-semibold mb-2">Password</label>
              <input
                type="password"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                className="w-full border border-gray-300 p-2 rounded focus:outline-none focus:border-blue-500"
                required
              />
            </div>
            <button
              type="submit"
              className="w-full bg-blue-600 text-white font-bold py-2 px-4 rounded hover:bg-blue-700 transition-colors mt-2"
            >
              Register
            </button>
            <p className="mt-4 text-center text-gray-600 text-sm">
              Already have an account? <Link href="/login" className="text-blue-600 hover:underline">Sign In</Link>
            </p>
          </form>
        )}
      </div>
    </div>
  );
}
