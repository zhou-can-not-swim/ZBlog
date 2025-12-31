// src/types/wangeditor.d.ts
declare module '@wangeditor/editor-for-react' {
  import { ComponentType } from 'react';
  import { IDomEditor, IEditorConfig, IToolbarConfig } from '@wangeditor/editor';
  
  interface ToolbarProps {
    editor: IDomEditor | null;
    defaultConfig: Partial<IToolbarConfig>;
    mode?: 'default' | 'simple';
    style?: React.CSSProperties;
    className?: string;
  }
  
  interface EditorProps {
    defaultConfig: Partial<IEditorConfig>;
    value: string;
    onCreated: (editor: IDomEditor) => void;
    onChange: (editor: IDomEditor) => void;
    mode?: 'default' | 'simple';
    style?: React.CSSProperties;
    className?: string;
  }
  
  export const Toolbar: ComponentType<ToolbarProps>;
  export const Editor: ComponentType<EditorProps>;
}