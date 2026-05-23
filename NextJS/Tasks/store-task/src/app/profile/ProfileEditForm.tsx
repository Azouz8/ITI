"use client";

import { useState } from "react";
import { useMutation, useQueryClient } from "@tanstack/react-query";

interface User {
  id: number;
  firstName: string;
  lastName: string;
  email: string;
}

export default function ProfileEditForm({ user }: { user: User }) {
  const [firstName, setFirstName] = useState(user.firstName);
  const [lastName, setLastName] = useState(user.lastName);
  const [email, setEmail] = useState(user.email);
  const queryClient = useQueryClient();

  const mutation = useMutation({
    mutationFn: async (updatedData: Partial<User>) => {
      const res = await fetch(`https://dummyjson.com/users/${user.id}`, {
        method: "PUT" /* or PATCH */,
        headers: { "Content-Type": "application/json" },
        body: JSON.stringify(updatedData),
      });
      if (!res.ok) throw new Error("Failed to update profile");
      return res.json();
    },
    onSuccess: (data) => {},
  });

  const handleSubmit = (e: React.FormEvent) => {
    e.preventDefault();
    mutation.mutate({ firstName, lastName, email });
  };

  return (
    <form onSubmit={handleSubmit} className="flex flex-col gap-4">
      {mutation.isSuccess && (
        <div className="bg-green-50 text-green-700 p-3 rounded border border-green-200">
          Profile updated successfully!
        </div>
      )}
      {mutation.isError && (
        <div className="bg-red-50 text-red-600 p-3 rounded border border-red-200">
          {mutation.error.message}
        </div>
      )}

      <div className="flex gap-4">
        <div className="flex-1">
          <label className="block text-gray-700 text-sm font-semibold mb-1">
            First Name
          </label>
          <input
            type="text"
            value={firstName}
            onChange={(e) => setFirstName(e.target.value)}
            className="w-full border border-gray-300 p-2 rounded"
          />
        </div>
        <div className="flex-1">
          <label className="block text-gray-700 text-sm font-semibold mb-1">
            Last Name
          </label>
          <input
            type="text"
            value={lastName}
            onChange={(e) => setLastName(e.target.value)}
            className="w-full border border-gray-300 p-2 rounded"
          />
        </div>
      </div>
      <div>
        <label className="block text-gray-700 text-sm font-semibold mb-1">
          Email
        </label>
        <input
          type="email"
          value={email}
          onChange={(e) => setEmail(e.target.value)}
          className="w-full border border-gray-300 p-2 rounded"
        />
      </div>

      <button
        type="submit"
        disabled={mutation.isPending}
        className="self-start bg-blue-600 text-white px-6 py-2 rounded hover:bg-blue-700 disabled:opacity-50"
      >
        {mutation.isPending ? "Saving..." : "Save Changes"}
      </button>
    </form>
  );
}
