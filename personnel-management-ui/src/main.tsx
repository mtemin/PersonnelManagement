import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import {
  createBrowserRouter,
  RouterProvider,
} from "react-router-dom";
import Home from './routes/Home.tsx';
import ErrorPage from './routes/ErrorPage.tsx';
import Register from './routes/Register.tsx';
import Login from './components/Login.tsx';
import App from "@/App.tsx";
import Navbar from "@/components/Navbar.tsx";

const router = createBrowserRouter([
  {
    path: "/",
    element: <Home />,
    errorElement: <ErrorPage />,
  },
  {
    path: "/login",
    element: <Login />,
  },
  {
    path: "/register",
    element: <Register />,
  },
]);

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <Navbar/>
    <RouterProvider router={router}>
       <App />
    </RouterProvider>
  </StrictMode>,
)
