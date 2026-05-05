import "./App.css";
import Home from "./pages/Home/Home";
import "bootstrap/dist/css/bootstrap.min.css";
import Login from "./pages/Login/Login";
import Signup from "./pages/Signup/Signup";
import { createBrowserRouter, RouterProvider } from "react-router";
import Layout from "./pages/Layout";
import PostPage from "./pages/PostPage/PostPage";
import ProtectedRoute from "./ProtectedRoute";
import NotFoundPage from "./pages/NotFoundPage/NotFoundPage";
import PostProvider from "./context/PostProvider";
import { Toaster } from "react-hot-toast";

function App() {
  const routerConfig = createBrowserRouter([
    {
      path: "/login",
      element: <Login />,
    },
    {
      path: "/signup",
      element: <Signup />,
    },
    {
      path: "/",
      element: (
        <ProtectedRoute>
          <Layout />
        </ProtectedRoute>
      ),
      children: [
        { index: true, element: <Home /> },
        { path: "/home", element: <Home /> },
        {
          path: "/post/:id",
          element: <PostPage />,
        },
      ],
    },
    { path: "*", element: <NotFoundPage /> },
  ]);

  return (
    <>
      <Toaster position="top-right" />
      <PostProvider>
        <RouterProvider router={routerConfig} />
      </PostProvider>
    </>
  );
}

export default App;
