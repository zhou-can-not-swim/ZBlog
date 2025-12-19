// ContentPage.tsx
import React from 'react';
import { useParams } from 'react-router-dom';

const ContentPage: React.FC = () => {
  const { id } = useParams<{ id: string }>();
  
  return (
    <div>
      <h1>内容详情页</h1>
      <p>当前内容ID: {id}</p>
      {/* 根据id获取具体内容并展示 */}
    </div>
  );
};

export default ContentPage;