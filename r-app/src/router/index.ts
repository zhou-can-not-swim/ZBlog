import LayoutPage from "../pages/LayoutPage";
import ContentPage from "../pages/ContentPage";

import { createBrowserRouter } from "react-router-dom";
import App1 from "../componentsTest/Test/index"
import AvatarComponent from "../componentsTest/Avatar";
import AppComponent from "../pages/TestComponents";
import Counter from "../componentsTest/Store/Counter";
import MarkD from "../componentsTest/Md";
import EditMd from "../components/EditMd";
import WritePage from "../pages/AdminPage/WritePage";

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
    path:"/admin/edit",
    id:"edit",
    Component: WritePage
  },
  {
    path: "/test",
    id: "测试",
    Component: AppComponent, // 父路由组件
    children: [ // 子路由配置
      {
        path: "avatar", // 相对路径，实际路径为 /test/avatar
        Component: AvatarComponent,
      },
      {
        path: "store", // 相对路径，实际路径为 /test/
        Component: Counter,
      },
            {
        path: "fuwenben", // 相对路径，实际路径为 /test/
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