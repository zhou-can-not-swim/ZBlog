import LayoutPage from "../pages/LayoutPage";
import ContentPage from "../pages/ContentPage";

import { createBrowserRouter } from "react-router-dom";
import App1 from "../pages/Test/index"
import AvatarComponent from "../components/Avatar";
import AppComponent from "../pages/TestComponents";
import Counter from "../components/Store/Counter";
import MarkD from "../components/Md";

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
  }, {
    path: "/test",
    id: "测试",
    Component: AppComponent, // 父路由组件
    children: [ // 子路由配置
      {
        path: "avatar", // 相对路径，实际路径为 /test/avatar
        Component: AvatarComponent,
      },
      {
        path: "store", // 相对路径，实际路径为 /test/recipes/beam
        Component: Counter,
      },
            {
        path: "app1", // 相对路径，实际路径为 /test/recipes/beam
        Component: App1,
      },
      {
        path:"md",
        Component:MarkD
      },
    ],
  },
]);

export default router