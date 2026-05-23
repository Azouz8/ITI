import { auth } from "@/auth";
import { redirect } from "next/navigation";
import Image from "next/image";
import ProfileEditForm from "./ProfileEditForm";
import OrderHistory from "./OrderHistory";

export const metadata = {
  title: "User Profile - Store",
};

async function getUserProfile(id: string) {
  const res = await fetch(`https://dummyjson.com/users/${id}`);
  if (!res.ok) throw new Error("Failed to fetch profile");
  return res.json();
}

export default async function ProfilePage() {
  const session = await auth();

  if (!session || !session.user || !session.user.id) {
    redirect("/login");
  }

  const userProfile = await getUserProfile(session.user.id as string);

  return (
    <div className="p-6 max-w-5xl mx-auto">
      <h1 className="text-3xl font-bold mb-8">My Account</h1>

      <div className="grid grid-cols-1 md:grid-cols-3 gap-8">
        <div className="md:col-span-1 border border-gray-300 p-6 self-start flex flex-col items-center text-center bg-gray-50">
          <div className="w-32 h-32 relative rounded-full overflow-hidden mb-4 bg-white border border-gray-200">
            {userProfile.image ? (
              <Image src={userProfile.image} alt={userProfile.username} fill className="object-cover" />
            ) : (
              <div className="w-full h-full bg-gray-300 flex items-center justify-center text-3xl text-white">
                {userProfile.firstName?.[0]}
              </div>
            )}
          </div>
          <h2 className="text-xl font-bold">{userProfile.firstName} {userProfile.lastName}</h2>
          <p className="text-gray-500 mb-2">@{userProfile.username}</p>
          <p className="text-sm text-gray-600">{userProfile.email}</p>
        </div>

        <div className="md:col-span-2 flex flex-col gap-8">
          <section className="border border-gray-300 p-6">
            <h2 className="text-2xl font-bold mb-4">Edit Profile</h2>
            {/* Client Component using TanStack Query */}
            <ProfileEditForm user={userProfile} />
          </section>

          <section className="border border-gray-300 p-6">
            <h2 className="text-2xl font-bold mb-4">Order History</h2>
            {/* Server Component fetching orders */}
            <OrderHistory userId={session.user.id as string} />
          </section>
        </div>
      </div>
    </div>
  );
}
