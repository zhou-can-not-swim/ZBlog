import React from 'react';
import { createRoot } from 'react-dom/client';
import './index.css';

//添加router的配置信息
import { RouterProvider } from 'react-router-dom';
import router from './router';

const root = createRoot(document.getElementById("root"));
root.render(
  <React.StrictMode>
    {/* App组件不需要了 ，改成router*/}
    <RouterProvider router={router}></RouterProvider>
  </React.StrictMode>
);
