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
import {Companies} from "@/routes/Companies.tsx";
import Employees from "@/routes/Employees.tsx";
import Expenses from "@/routes/Expenses.tsx";
import LeaveDays from "@/routes/LeaveDays.tsx";

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
    {
    path: "/companies",
    element: <Companies />,
  },
  {
    path: "/employees",
    element: <Employees />,
  },
    {
    path: "/expenses",
    element: <Expenses />,
  },
    {
    path: "/leavedays",
    element: <LeaveDays />,
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
