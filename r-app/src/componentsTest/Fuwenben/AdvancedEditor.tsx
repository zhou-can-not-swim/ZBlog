// src/components/AdvancedEditor.tsx
import React, { useState, useEffect } from 'react';
import { Editor, Toolbar } from '@wangeditor/editor-for-react';
import type { 
  IDomEditor, 
  IEditorConfig, 
  IToolbarConfig 
} from '@wangeditor/editor';
import '@wangeditor/editor/dist/css/style.css';

// 定义工具栏按钮类型
type ToolbarKey = 
  | 'headerSelect' 
  | 'bold' 
  | 'italic'
  | 'underline'
  | 'color'
  | 'bgColor'
  | 'fontSize'
  | 'fontFamily'
  | 'insertLink'
  | 'insertImage'
  | 'undo'
  | 'redo';

interface AdvancedEditorProps {
  value?: string;
  onChange?: (value: string) => void;
  toolbarKeys?: ToolbarKey[];
  disabled?: boolean;
}

const AdvancedEditor: React.FC<AdvancedEditorProps> = ({
  value = '',
  onChange,
  toolbarKeys = [
    'headerSelect',
    'bold', 'italic', 'underline',
    'color', 'bgColor',
    'fontSize', 'fontFamily',
    'insertLink', 'insertImage',
    'undo', 'redo'
  ],
  disabled = false
}) => {
  const [editor, setEditor] = useState<IDomEditor | null>(null);
  const [html, setHtml] = useState(value);

  // 自定义图片上传
  const customUploadImage = (file: File, insertFn: (url: string) => void) => {
    // 创建FormData
    const formData = new FormData();
    formData.append('file', file);

    // 模拟上传
    console.log('开始上传:', file.name);
    
    // 这里替换为你的上传逻辑
    setTimeout(() => {
      // 假设上传成功，返回一个本地URL
      const mockUrl = URL.createObjectURL(file);
      insertFn(mockUrl);
      console.log('上传完成:', mockUrl);
    }, 1000);
  };

  // 编辑器配置
  const editorConfig: Partial<IEditorConfig> = {
    placeholder: '请输入内容...',
    readOnly: disabled,
    MENU_CONF: {
      uploadImage: {
        customUpload: customUploadImage,
      },
      insertLink: {
        checkLink: (text: string, url: string) => {
          // 验证链接
          if (!url) {
            alert('请输入链接地址');
            return false;
          }
          if (!url.startsWith('http')) {
            alert('链接必须以 http:// 或 https:// 开头');
            return false;
          }
          return true;
        },
      },
    },
  };

  // 工具栏配置
  const toolbarConfig: Partial<IToolbarConfig> = {
    toolbarKeys: toolbarKeys,
    excludeKeys: disabled ? [] : [], // 禁用时可设置排除的按钮
  };

  // 销毁编辑器
  useEffect(() => {
    return () => {
      editor?.destroy();
    };
  }, [editor]);

  // 监听外部value变化
  useEffect(() => {
    setHtml(value);
  }, [value]);

  // 处理内容变化
  const handleChange = (editor: IDomEditor) => {
    const newHtml = editor.getHtml();
    setHtml(newHtml);
    onChange?.(newHtml);
  };

  return (
    <div className="advanced-editor" style={{ border: '1px solid #ccc' }}>
      {!disabled && (
        <Toolbar
          editor={editor}
          defaultConfig={toolbarConfig}
          mode="simple"
          style={{ borderBottom: '1px solid #ccc' }}
        />
      )}
      
      <Editor
        defaultConfig={editorConfig}
        value={html}
        onCreated={setEditor}
        onChange={handleChange}
        mode="simple"
        style={{ height: '350px' }}
      />
    </div>
  );
};

export default AdvancedEditor;