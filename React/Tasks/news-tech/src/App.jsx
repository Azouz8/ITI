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
import { Toaster } from "react-hot-toast";
import { storeConfig } from "./redux/store/store";
import { Provider } from "react-redux";

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
      <Provider store={storeConfig}>
        <RouterProvider router={routerConfig} />
      </Provider>
    </>
  );
}

export default App;
