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
import ReactQueryClient from "@/components/provider/ReactQueryClient.tsx";
import Profile from "@/routes/Profile.tsx";
import CompanyProfile from "@/routes/CompanyProfile.tsx";
import EmployeeProfile from "@/routes/EmployeeProfile.tsx";

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
    path: "/employee/:employeeId",
    element: <Profile />,
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
    path: "/company/:companyId",
    element: <CompanyProfile />,
  },

]);

createRoot(document.getElementById('root')!).render(
  <StrictMode>
    <ReactQueryClient>
    <Navbar/>
    <RouterProvider router={router}>
       <App />
    </RouterProvider>
    </ReactQueryClient>
  </StrictMode>
)
