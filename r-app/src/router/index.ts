import LayoutPage from "../pages/LayoutPage";
import ContentPage from "../pages/ContentPage";

import { createBrowserRouter } from "react-router-dom";

//配置
const router = createBrowserRouter([
  {
    path: "/",
    id:"main",
    Component: LayoutPage,
  },
  {
    path: "/content/:id",
    id:"content",
    Component: ContentPage,
  }
]);

export default router