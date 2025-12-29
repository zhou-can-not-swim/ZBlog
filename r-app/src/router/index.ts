import LayoutPage from "../pages/LayoutPage";
import ContentPage from "../pages/ContentPage";

import { createBrowserRouter } from "react-router-dom";
import App1 from "../pages/Test/index"

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
  },{
    path:"/test",
    id:"test",
    Component:App1
  }
]);

export default router