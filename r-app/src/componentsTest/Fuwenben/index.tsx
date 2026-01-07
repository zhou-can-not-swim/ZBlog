// src/App.tsx
import React, { useState } from 'react';
import MyEditor from './MyEditor';

const Fuwenben: React.FC = () => {
  const [editorContent, setEditorContent] = useState<string>('');

  // 获取编辑器内容
  const getEditorContent = () => {
    console.log('编辑器内容:', editorContent);
    alert('内容已打印到控制台');
  };

  // 清空编辑器内容
  const clearEditor = () => {
    setEditorContent('');
  };

  // 设置预设内容
  const setPresetContent = () => {
    setEditorContent('<h1>标题</h1><p>这是一段预设内容</p>');
  };

  return (
    <div style={{ padding: '20px' }}>
      <h1>WangEditor 富文本编辑器示例</h1>
      
      {/* 使用编辑器组件 */}
      <MyEditor 
        value={editorContent}
        onChange={setEditorContent}
        height={400}
      />
      
      <div style={{ marginTop: '20px' }}>
        <button 
          onClick={getEditorContent}
          style={{ marginRight: '10px', padding: '8px 16px' }}
        >
          获取内容
        </button>
        
        <button 
          onClick={clearEditor}
          style={{ marginRight: '10px', padding: '8px 16px' }}
        >
          清空内容
        </button>
        
        <button 
          onClick={setPresetContent}
          style={{ padding: '8px 16px' }}
        >
          设置预设内容
        </button>
      </div>
      
      {/* 预览区域 */}
      <div style={{ marginTop: '30px' }}>
        <h2>内容预览：</h2>
        <div 
          style={{ 
            border: '1px solid #eee', 
            padding: '20px', 
            minHeight: '100px',
            backgroundColor: '#f9f9f9'
          }}
          dangerouslySetInnerHTML={{ __html: editorContent }}
        />
      </div>
      
      {/* 原始HTML显示 */}
      <div style={{ marginTop: '30px' }}>
        <h2>原始HTML：</h2>
        <pre style={{ 
          backgroundColor: '#f5f5f5', 
          padding: '15px', 
          overflow: 'auto',
          maxHeight: '200px'
        }}>
          {editorContent}
        </pre>
      </div>
    </div>
  );
};

export default Fuwenben;