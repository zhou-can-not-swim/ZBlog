// src/App.tsx
import React, { useEffect, useState } from 'react';
import SimpleMDEditor from './SimpleMDEditor';
// 先导入组件
import ReactMarkdownPreview from '@uiw/react-markdown-preview';


interface MarkDProps {
  // 根据你的使用场景，blogDetail 是包含 title/content 的对象
  blogDetail: {
    title?: string; // 可选属性（因为用了 data?.title）
    content?: string;
  };
}
const MarkD: React.FC<MarkDProps> = ({ blogDetail}) => {
  const [content, setContent] = useState<string>('');

  // 获取内容
  const getContent = () => {
    console.log('编辑器内容:', content);
    alert('内容已打印到控制台');
  };

  // 清空内容
  const clearContent = () => {
    setContent('');
  };

  // 设置预设内容
  useEffect(()=>{
        setContent(blogDetail.content||'');
  })
  

  return (
    <div style={{ padding: '20px', maxWidth: '1200px', margin: '0 auto' }}>

      {/* // 预览区域替换为： */}
      <div style={{ marginTop: '30px' }}>
        <h2>实时预览：</h2>
        <div style={{
          border: '1px solid #e8e8e8',
          padding: '20px',
          minHeight: '200px',
          backgroundColor: '#fafafa',
          borderRadius: '4px'
        }}>
          {content ? (
            <ReactMarkdownPreview
              source={content}
              style={{ backgroundColor: 'transparent' }}
            />
          ) : (
            <div style={{ color: '#999', textAlign: 'center', padding: '40px' }}>
              暂无内容
            </div>
          )}
        </div>
      </div>

    </div>
  );
};

export default MarkD;