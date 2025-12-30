import React, { useState } from 'react';
import { UserOutlined } from '@ant-design/icons';
import { Avatar, Button, Card, Checkbox, Form, Input, Modal, Space } from 'antd';

import type { FormProps } from 'antd';
import { API } from "../../services/Admin/typings";
import "./index.css"
import { useAppDispatch, useAppSelector } from '../../stores/hooks';
import { setEmail, setMotto, setUserName } from '../../stores/userSlice';

const AvatarComponent: React.FC = () => {
    //导入store
    const username = useAppSelector((state) => state.user.username);
    const email = useAppSelector((state) => state.user.email);
    const motto = useAppSelector((state) => state.user.motto);
    const dispatch = useAppDispatch();

    const [isOnOff, setOnOff] = useState(false)

    //modal
    const [isModalOpen, setIsModalOpen] = useState(false);

    const showModal = () => {
        setIsModalOpen(true);
    };

    const handleOk = () => {
        setIsModalOpen(false);
    };

    const handleCancel = () => {
        setIsModalOpen(false);
    };
    // form
    const onFinish: FormProps<API.FieldType>['onFinish'] = (values) => {
        console.log('Success:', values);
        localStorage.setItem("jwt", "xxxxxxxxxxxxxxxxxxx")
        dispatch(setUserName("xxxx"))
        dispatch(setMotto("xxxx"))
        dispatch(setEmail("xxxx"))

    };

    const onFinishFailed: FormProps<API.FieldType>['onFinishFailed'] = (errorInfo) => {
        console.log('Failed:', errorInfo);
    };

    const onForm = () => {
        setOnOff(!isOnOff)
    }

    return (
        <>
            <Card title="Hi" extra={<Button onClick={showModal}>获取成为超级管理员</Button>} style={{ width: 300 }}>
                <Avatar size={64} icon={<UserOutlined />} />
                <p>{username}</p>
                <p>{email}</p>
                <p>{motto}</p>
            </Card>

            <Modal
                title="登录管理员账号"
                closable={{ 'aria-label': 'Custom Close Button' }}
                open={isModalOpen}
                onOk={handleOk}
                onCancel={handleCancel}
            >
                <Form
                    name="登录管理员账号"
                    labelCol={{ span: 8 }}
                    wrapperCol={{ span: 16 }}
                    style={{ maxWidth: 600 }}
                    initialValues={{ remember: true }}
                    onFinish={onFinish}
                    onFinishFailed={onFinishFailed}
                    autoComplete="off"
                >
                    <Form.Item<API.FieldType>
                        label="Username"
                        name="username"
                        rules={[{ required: true, message: 'Please input your username!' }]}
                    >
                        <Input />
                    </Form.Item>

                    <Form.Item<API.FieldType>
                        label="Password"
                        name="password"
                        rules={[{ required: true, message: 'Please input your password!' }]}
                    >
                        <Input.Password />
                    </Form.Item>

                    <Form.Item<API.FieldType> name="remember" valuePropName="checked" label={null}>
                        <Checkbox>Remember me</Checkbox>
                    </Form.Item>

                    <Form.Item label={null}>
                        <Button type="primary" htmlType="submit">
                            Submit
                        </Button>
                    </Form.Item>
                </Form>
            </Modal>



        </>




    )
}


export default AvatarComponent;
