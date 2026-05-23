"use client";
import { useState } from "react";

export default function TruncatedDescription({ text, limit = 60 }: { text: string, limit?: number }) {
  const [isExpanded, setIsExpanded] = useState(false);
  
  if (!text) return null;
  if (text.length <= limit) return <p className="text-gray-600 text-sm mb-2">{text}</p>;
  
  return (
    <div className="text-gray-600 text-sm mb-2">
      {isExpanded ? text : `${text.substring(0, limit)}...`}
      <button 
        onClick={() => setIsExpanded(!isExpanded)}
        className="text-blue-600 hover:underline ml-1 font-semibold"
      >
        {isExpanded ? "see less" : "see more"}
      </button>
    </div>
  );
}
