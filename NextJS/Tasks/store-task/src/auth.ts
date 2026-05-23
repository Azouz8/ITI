import NextAuth from "next-auth";
import CredentialsProvider from "next-auth/providers/credentials";

export const { handlers, signIn, signOut, auth } = NextAuth({
  secret: process.env.AUTH_SECRET || "my-super-secret-store-task-key-12345",
  providers: [
    CredentialsProvider({
      name: "Credentials",
      credentials: {
        username: { label: "Username", type: "text" },
        password: { label: "Password", type: "password" },
      },
      async authorize(credentials) {
        if (!credentials?.username || !credentials?.password) return null;

        try {
          const res = await fetch("https://dummyjson.com/auth/login", {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({
              username: credentials.username,
              password: credentials.password,
            }),
          });

          const user = await res.json();

          if (res.ok && user) {
            return {
              id: user.id.toString(),
              name: `${user.firstName} ${user.lastName}`,
              email: user.email,
              image: user.image,
              accessToken: user.token,
            };
          }
          return null;
        } catch (error) {
          console.error("Auth error:", error);
          return null;
        }
      },
    }),
  ],
  callbacks: {
    async jwt({ token, user }) {
      if (user) {
        token.accessToken = (user as any).accessToken;
        token.id = user.id;
      }
      return token;
    },
    async session({ session, token }) {
      session.user.id = token.id as string;
      (session as any).accessToken = token.accessToken as string;
      return session;
    },
  },
  pages: {
    signIn: "/login",
  },
});
