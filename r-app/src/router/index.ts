import LayoutPage from "../pages/LayoutPage";
import ContentPage from "../pages/ContentPage";

import { createBrowserRouter } from "react-router-dom";
import AvatarComponent from "@/components/Avatar";
import AppComponent from "../pages/TestPages";
import Counter from "../componentsTest/Store/Counter";
import MarkD from "../componentsTest/Md";
import WritePage from "../pages/AdminPage/WritePage";
import LoginPage from "../pages/LoginPage";
import Fuwenben from "../componentsTest/Fuwenben/index";
import TestRoles from "../componentsTest/TestRoles";
import Buju from "@/componentsTest/Buju";
import TestAxios from "@/componentsTest/TestAxios";
import FourZeroOne from "@/pages/ErrorPage/401";
import ErrorPage from "@/pages/ErrorPage";
import UpdateMd from "@/components/UpdateMd";
import UpdatePage from "@/pages/AdminPage/UpdatePage";

//配置
const router = createBrowserRouter([
  {
    path: "/",
    id:"main",
    Component: LayoutPage,
  },
  {
    path:"/login",
    id:"login",
    Component:LoginPage
  },
  {
    path: "/content/:id",
    id:"content",
    Component: ContentPage,
  }, {
    path:"/admin/edit",
    id:"edit",
    Component: WritePage
  },{
    path:"/admin/update/:id",
    id:"update",
    Component: UpdatePage
  },{
    path:"/error",
    id:"error",
    Component: ErrorPage, // 父路由组件
    children: [ // 子路由配置
      {
        path: "401", // 相对路径，实际路径为 /error/401
        Component: FourZeroOne,
      }]
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
        path: "store", // 相对路径，实际路径为 /test/store
        Component: Counter,
      },
            {
        path: "fuwenben", // 相对路径，实际路径为 /test/fuwenben
        Component: Fuwenben,
      },
      {
        path:"md",        // 相对路径，实际路径为 /test/md
        Component:MarkD
      },{
        path:"role",        // 相对路径，实际路径为 /test/role
        Component:TestRoles
      },{
        path:"buju",        // 相对路径，实际路径为 /test/role
        Component:Buju
      },{
        path:"taxios",        // 相对路径，实际路径为 /test/axios
        Component:TestAxios
      }
    ],
  },
]);

export default router