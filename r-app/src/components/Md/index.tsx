// src/App.tsx
import React, { useState } from 'react';
import SimpleMDEditor from './SimpleMDEditor';

const MarkD: React.FC = () => {
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
  const setPresetContent = () => {
    setContent(`# 预设内容

这是一段预设的Markdown内容。

## 功能列表
- ✅ 支持Markdown语法
- ✅ 实时预览
- ✅ 工具栏操作
- ✅ 代码高亮

\`\`\`javascript
// 示例代码
const message = "Hello, Markdown!";
console.log(message);
\`\`\``);
  };

  return (
    <div style={{ padding: '20px', maxWidth: '1200px', margin: '0 auto' }}>
      <h1>MDEditor 富文本编辑器示例</h1>
      
      {/* 使用编辑器 */}
      <SimpleMDEditor
        value={content}
        onChange={setContent}
        height={400}
        placeholder="开始写作..."
      />
      
      {/* 操作按钮 */}
      <div style={{ marginTop: '20px', display: 'flex', gap: '10px' }}>
        <button 
          onClick={getContent}
          style={{ 
            padding: '8px 16px', 
            backgroundColor: '#1890ff', 
            color: 'white', 
            border: 'none', 
            borderRadius: '4px',
            cursor: 'pointer'
          }}
        >
          获取内容
        </button>
        
        <button 
          onClick={clearContent}
          style={{ 
            padding: '8px 16px', 
            backgroundColor: '#ff4d4f', 
            color: 'white', 
            border: 'none', 
            borderRadius: '4px',
            cursor: 'pointer'
          }}
        >
          清空内容
        </button>
        
        <button 
          onClick={setPresetContent}
          style={{ 
            padding: '8px 16px', 
            backgroundColor: '#52c41a', 
            color: 'white', 
            border: 'none', 
            borderRadius: '4px',
            cursor: 'pointer'
          }}
        >
          设置预设内容
        </button>
      </div>
      
      {/* 预览区域 */}
      <div style={{ marginTop: '30px' }}>
        <h2>实时预览：</h2>
        <div style={{ 
          border: '1px solid #e8e8e8', 
          padding: '20px', 
          minHeight: '200px',
          backgroundColor: '#fafafa',
          borderRadius: '4px'
        }}>
          {/* 直接显示HTML预览 */}
          <div data-color-mode="light">
            <div className="wmde-markdown">
              {content ? (
                <div dangerouslySetInnerHTML={{ 
                  __html: require('@uiw/react-markdown-preview').default({
                    source: content,
                    style: { backgroundColor: 'transparent' }
                  }).props.children 
                }} />
              ) : (
                <div style={{ color: '#999', textAlign: 'center', padding: '40px' }}>
                  暂无内容
                </div>
              )}
            </div>
          </div>
        </div>
      </div>
      
      {/* 原始文本显示 */}
      <div style={{ marginTop: '30px' }}>
        <h2>原始Markdown：</h2>
        <pre style={{ 
          backgroundColor: '#f5f5f5', 
          padding: '15px', 
          border: '1px solid #e8e8e8',
          borderRadius: '4px',
          overflow: 'auto',
          maxHeight: '200px',
          fontSize: '14px'
        }}>
          {content || '空内容'}
        </pre>
      </div>
    </div>
  );
};

export default MarkD;