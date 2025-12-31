// src/components/SimpleMDEditor.tsx
import React, { useState, useEffect } from 'react';
import MDEditor from '@uiw/react-md-editor';
import '@uiw/react-md-editor/markdown-editor.css';
import '@uiw/react-markdown-preview/markdown.css';

// 类型定义
interface SimpleMDEditorProps {
  value?: string;
  onChange?: (value: string) => void;
  height?: number;
  placeholder?: string;
  readOnly?: boolean;
}

const SimpleMDEditor: React.FC<SimpleMDEditorProps> = ({
  value = '',
  onChange,
  height = 400,
  placeholder = '请输入内容...',
  readOnly = false,
}) => {
  const [content, setContent] = useState<string>(value);

  // 监听外部value变化
  useEffect(() => {
    setContent(value);
  }, [value]);

  // 处理内容变化
  const handleChange = (newValue?: string) => {
    const val = newValue || '';
    setContent(val);
    onChange?.(val);
  };

  return (
    <div className="md-editor-wrapper">
      <MDEditor
        value={content}
        onChange={handleChange}
        height={height}
        preview={readOnly ? 'preview' : 'live'}
        hideToolbar={readOnly}
        textareaProps={{
          disabled: readOnly,
          placeholder: placeholder,
        }}
        style={{
          border: '1px solid #ccc',
          borderRadius: '4px',
          overflow: 'hidden',
        }}
      />
    </div>
  );
};

export default SimpleMDEditor;