"use client";

import React from "react";

interface Props {
  error: Error;
}

export default function Error({ error }: Props) {
  return (
    <div className="text-center mt-24">
      <p className="text-red-500 text-4xl font-bold mb-4">
        Something went wrong!
      </p>
      <p className="text-gray-400 text-lg">{error.message}</p>
    </div>
  );
}
