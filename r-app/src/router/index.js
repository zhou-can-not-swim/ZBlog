import Layout from "../pages/Layout";
import Login from "../pages/Login";

import { createBrowserRouter } from "react-router-dom";

//配置
const router = createBrowserRouter([
  {
    path: "/",
    name:"五",
    Component: Layout,
  },
  {
    path: "/login",
    name:"登录",
    Component: Login,
  }
]);

export default router