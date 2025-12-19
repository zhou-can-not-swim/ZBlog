import React from 'react';
import { LikeOutlined, MessageOutlined, StarOutlined } from '@ant-design/icons';
import { Avatar, Card, Col, Descriptions, List, Row, Space } from 'antd';
import { Link, useNavigate } from 'react-router-dom';
import "./index"

const data = Array.from({ length: 23 }).map((_, i) => ({
  href: 'https://ant.design',
  title: `ant design part ${i}`,
  avatar: `/content/` + i,
  description:
    '这是简介',
  content:
    '这是内容',
  id: i
}));

const IconText = ({ icon, text }: { icon: React.FC; text: string }) => (
  <Space>
    {React.createElement(icon)}
    {text}
  </Space>
);

const LayoutPage: React.FC = () => {
  const navigate = useNavigate(); // 获取navigate函数
  return <>
    <List
      itemLayout="vertical"
      size="small"
      pagination={{
        onChange: (page) => {
          console.log(page);
        },
        pageSize: 3,
      }}
      dataSource={data}
      footer={
        <div>
          <b>ant design</b> footer part
        </div>
      }
      renderItem={(item) => (
        <List.Item
          key={item.title}
          actions={[
            <IconText icon={StarOutlined} text="156" key="list-vertical-star-o" />,
            <IconText icon={LikeOutlined} text="156" key="list-vertical-like-o" />,
          ]}
          extra={
            <img
              draggable={false}
              width={200}
              alt="logo"
              src="https://gw.alipayobjects.com/zos/rmsportal/mqaQswcyDLcXyDKnZfES.png"
            />
          }
        >

          <List.Item.Meta
            avatar={
              <Avatar src={item.avatar} onClick={() => navigate(`/content/${item.id}`)} />
            }
            title={
              <a href={item.href}>{item.title}</a>
            }
            description={item.description}
          />
            {item.content}
            {item.avatar}
        </List.Item>
      )}
    />
  </>
};

export default LayoutPage;