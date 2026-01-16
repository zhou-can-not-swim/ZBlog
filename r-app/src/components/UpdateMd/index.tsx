// src/App.tsx
import React, { useEffect, useState } from 'react';
import SimpleMDEditor from './SimpleMDEditor';
import { Alert, Button, Checkbox, Form, Input, Modal, Select } from 'antd';
import { FormProps } from 'antd/es/form/Form';
import { submitBlogContent } from '../../services/blogs';
import { getTagsList } from '@/services/tags';
import { findOneBlog, updateBlog } from '@/services/blogs.axios';
import { useNavigate } from 'react-router-dom';

interface UpdateMdProps {
  blogId: string | undefined; // 匹配父组件传递的id类型（可能为undefined）
}
const UpdateMd: React.FC<UpdateMdProps> = ({blogId}) => {
    const [content, setContent] = useState<string>('');
    const [description, setdescription] = useState<string>('');
    const [title, setTitle] = useState<string>('');
    const [tagId,setTagId]=useState<number[]>([0])

    //得到blog数据
    useEffect(()=>{
        const getOneBlogToUpdate=async ()=>{
            if (!blogId) return;
            const blog =await findOneBlog({id:blogId});
            setTitle(blog.title);
            setContent(blog.content);
            setdescription(blog.description)
            setTagId(blog.tags)
        }
        getOneBlogToUpdate()
    },[])

    const submitContent = () => {
        setIsModalOpen(true);
    }

    // 弹出框
    const [isModalOpen, setIsModalOpen] = useState(false);
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
        debugger;
        var result = await updateBlog({id: blogId,title: values.title, description: values.description, content: content ,tagIds:tagId})
        console.log(result);
        <Alert title="Success Tips" type="success" showIcon />

    };

    const onFinishFailed: FormProps<FieldType>['onFinishFailed'] = (errorInfo) => {
        console.log('Failed:', errorInfo);
    };

    // select tag 选择器
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

            {/* 弹窗，title,desp.tag */}
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
                        initialValue={title}
                    >
                        <Input />
                    </Form.Item>

                    <Form.Item<FieldType>
                        label="简介"
                        name="description"
                        rules={[{ required: true, message: 'Please input your description!' }]}
                        initialValue={description}
                    >
                        <Input />
                    </Form.Item>

                    <Form.Item<FieldType>
                        label="标签"
                        name="tag"
                        rules={[{ required: true, message: 'Please input your description!' }]}
                        initialValue={tagId}
                    >
                        <Select
                            placeholder="Select a person"
                            style={{ width: 180 }}
                            onChange={handleChange}
                            defaultValue={tagId[0]}
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

export default UpdateMd;