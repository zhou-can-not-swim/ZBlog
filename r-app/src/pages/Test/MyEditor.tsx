// src/components/MyEditor.tsx
import React, { useState, useEffect } from 'react';
import { Editor, Toolbar } from '@wangeditor/editor-for-react';
import { 
  IDomEditor, 
  IEditorConfig, 
  IToolbarConfig,
  Boot 
} from '@wangeditor/editor';

// 引入必要的样式
import '@wangeditor/editor/dist/css/style.css';

// 定义组件的props类型
interface MyEditorProps {
  value?: string;
  onChange?: (value: string) => void;
  height?: number;
}

const MyEditor: React.FC<MyEditorProps> = ({ 
  value = '', 
  onChange, 
  height = 300 
}) => {
  // editor实例
  const [editor, setEditor] = useState<IDomEditor | null>(null);
  
  // 编辑器内容
  const [html, setHtml] = useState<string>(value);

  // 工具栏配置
  const toolbarConfig: Partial<IToolbarConfig> = {
    // 配置工具栏项
    toolbarKeys: [
      'headerSelect',
      'bold', 'italic', 'underline', 'color', 'bgColor',
      '|',
      'fontSize', 'fontFamily', 'lineHeight',
      '|',
      'bulletedList', 'numberedList', 'todo',
      '|',
      'emotion', 'insertLink', 'insertImage',
      '|',
      'undo', 'redo'
    ]
  };

  // 编辑器配置
  const editorConfig: Partial<IEditorConfig> = {
    placeholder: '请输入内容...',
    MENU_CONF: {
      // 图片上传配置
      uploadImage: {
        server: '/api/upload', // 你的上传接口
        fieldName: 'file', // 上传的字段名
        maxFileSize: 2 * 1024 * 1024, // 2M
        allowedFileTypes: ['image/*'],
        // 上传回调函数
        onSuccess(file: File, res: any) {
          console.log(`${file.name} 上传成功`, res);
        },
        onFailed(file: File, res: any) {
          console.log(`${file.name} 上传失败`, res);
        },
        onError(file: File, err: Error, res: any) {
          console.log(`${file.name} 上传出错`, err, res);
        },
      },
    },
  };

  // 及时销毁 editor
  useEffect(() => {
    return () => {
      if (editor == null) return;
      editor.destroy();
      setEditor(null);
    };
  }, [editor]);

  // 监听value变化
  useEffect(() => {
    setHtml(value);
  }, [value]);

  // 内容变化回调
  const handleEditorChange = (editor: IDomEditor) => {
    const newHtml = editor.getHtml();
    setHtml(newHtml);
    onChange && onChange(newHtml);
  };

  return (
    <div style={{ border: '1px solid #ccc', zIndex: 100 }}>
      {/* 工具栏 */}
      <Toolbar
        editor={editor}
        defaultConfig={toolbarConfig}
        mode="default"
        style={{ borderBottom: '1px solid #ccc' }}
      />
      
      {/* 编辑器 */}
      <Editor
        defaultConfig={editorConfig}
        value={html}
        onCreated={setEditor}
        onChange={handleEditorChange}
        mode="default"
        style={{ 
          height: `${height}px`, 
          overflowY: 'hidden' 
        }}
      />
    </div>
  );
};

export default MyEditor;