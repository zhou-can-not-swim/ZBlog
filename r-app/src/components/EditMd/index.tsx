// src/App.tsx
import React, { useEffect, useState } from 'react';
import SimpleMDEditor from './SimpleMDEditor';
import { Button, Checkbox, Form, Input, Modal, Select } from 'antd';
import { FormProps } from 'antd/es/form/Form';
import { submitBlogContent } from '../../services/blogs';
import { getTagsList } from '@/services/tags';

const EditMd: React.FC = () => {
    const [content, setContent] = useState<string>('');
    const [description, setdescription] = useState<string>('');
    const [title, setTitle] = useState<string>('');



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

    const submitContent = () => {
        setIsModalOpen(true);
    }

    // 弹出框
    const [isModalOpen, setIsModalOpen] = useState(false);

    const showModal = () => {
    };

    const handleOk = () => {
        setIsModalOpen(false);
    };

    const handleCancel = () => {
        setIsModalOpen(false);
    };


    //   form表单
    type FieldType = {
        title?: string;
        description?: string;
        tag: string;
    };

    const onFinish: FormProps<FieldType>['onFinish'] = async (values) => {//values {},代表title和description
        //调用后端接口
        var result = await submitBlogContent({ title: values.title, description: values.description, content: content ,tagIds:tagId})
        console.log(result);
    };

    const onFinishFailed: FormProps<FieldType>['onFinishFailed'] = (errorInfo) => {
        console.log('Failed:', errorInfo);
    };

    // select tag 选择器
    const [tagId,setTagId]=useState<number[]>()
    const handleChange = (value: number) => {
        setTagId([value])
        console.log(`selected ${value}`);
    };

    //tag设置
    const [list, setList] = useState<TagApi.TagItem[]>([])
    const [options,setOptions]=useState<TagApi.TagOptions[]>([])
    useEffect(() => {
        const getAllList = async () => {
            const v = await getTagsList();
            setList(v)

            return v;
        }
        getAllList()

    }, [content])

    useEffect(() => {
        const transformedOptions = list.map(item => ({
            value: item.id,
            label: item.name,
        }));
        setOptions(transformedOptions)

    }, [list])

    return (
        <div style={{ padding: '20px', maxWidth: '1200px', margin: '0 auto' }}>
            {/* <h1>MDEditor 富文本编辑器示例</h1> */}

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
            <Modal
                title="Basic Modal"
                closable={{ 'aria-label': 'Custom Close Button' }}
                open={isModalOpen}
                onOk={handleOk}
                onCancel={handleCancel}
            >
                <Form
                    name="basic"
                    labelCol={{ span: 8 }}
                    wrapperCol={{ span: 16 }}
                    style={{ maxWidth: 600 }}
                    onFinish={onFinish}
                    onFinishFailed={onFinishFailed}
                    autoComplete="off"
                >
                    <Form.Item<FieldType>
                        label="标题"
                        name="title"
                        rules={[{ required: true, message: 'Please input your 标题!' }]}
                    >
                        <Input />
                    </Form.Item>

                    <Form.Item<FieldType>
                        label="简介"
                        name="description"
                        rules={[{ required: true, message: 'Please input your description!' }]}
                    >
                        <Input />
                    </Form.Item>

                    <Form.Item<FieldType>
                        label="标签"
                        name="tag"
                        rules={[{ required: true, message: 'Please input your description!' }]}
                    >
                        <Select
                            placeholder="Select a person"
                            style={{ width: 180 }}
                            onChange={handleChange}
                            options={options}
                        />
                    </Form.Item>


                    <Form.Item label={null}>
                        <Button type="primary" htmlType="submit">
                            Submit
                        </Button>
                    </Form.Item>
                </Form>
            </Modal>
        </div>
    );
};

export default EditMd;