// src/App.tsx
import React, { useState } from 'react';
import SimpleMDEditor from './SimpleMDEditor';

const EditMd: React.FC = () => {
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

const submitContent=()=>{
    alert("提交了")
    
}



    return (
        <div style={{ padding: '20px', maxWidth: '1200px', margin: '0 auto' }}>
            <h1>MDEditor 富文本编辑器示例</h1>

            {/* 使用编辑器 */}
            <SimpleMDEditor
                value={content}
                onChange={setContent}
                height={600}
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

                <button
                    onClick={submitContent}
                    style={{
                        padding: '8px 16px',
                        backgroundColor: '#0253e9ff',
                        color: 'white',
                        border: 'none',
                        borderRadius: '4px',
                        cursor: 'pointer'
                    }}
                >
                    提交内容
                </button>
            </div>

        </div>
    );
};

export default EditMd;