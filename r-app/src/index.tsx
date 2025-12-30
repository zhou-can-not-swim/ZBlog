import React from 'react';
import { createRoot } from 'react-dom/client';
import './index.css';

//添加router的配置信息
import { RouterProvider } from 'react-router-dom';
import router from './router';
import { Provider } from 'react-redux';
import { store } from './stores/store';

const root = createRoot(document.getElementById("root") as HTMLElement);
root.render(
  <React.StrictMode>
    {/* App组件不需要了 ，改成router*/}
    <Provider store={store}>
    <RouterProvider router={router}></RouterProvider>
    </Provider>
  </React.StrictMode>
);
