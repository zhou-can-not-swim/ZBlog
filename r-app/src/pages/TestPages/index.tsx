// App1.jsx 或 App1.tsx
import React from 'react';
import { Outlet, Link, useNavigate } from 'react-router-dom';

const AppComponent = () => {
  return (
    <div>
      <h1>测试页面</h1>
      
      {/* 导航菜单 */}
      <nav>
        <Link to="/test/avatar">头像--</Link>
        <Link to="/test/store">store--</Link>
        <Link to="/test/md">md--</Link>
        <Link to="/test/fuwenben">富文本--</Link>
        <Link to="/test/role">权限测试--</Link>
        <Link to="/test/buju">布局--</Link>
        <Link to="/test/taxios">测试axios--</Link>
        {/* <Link to="recipes/beam">Beam配方</Link> */}
      </nav>
      
      {/* 子路由内容将在此处渲染 */}
      <Outlet />
    </div>
  );
};

export default AppComponent;