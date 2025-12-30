import React, { useState, useMemo, useEffect, useRef } from 'react';
import { Avatar, Button, Card, Col, Descriptions, List, Row, Space } from 'antd';
// import "./index.css"

import { UserOutlined } from '@ant-design/icons';

import { Flex, Radio, Pagination } from 'antd';
import { getAllBlogs } from '../../services/blogList';

const LayoutPage: React.FC = () => {
  const PAGE_SIZE = 5; // 每页显示的数量
  const [len, setLen] = useState(100);
  const [currentPage, setCurrentPage] = useState(1); // 当前页码
  const [data, setData] = useState<BlogApi.BlogItem[]>([])

  const flag = useRef(true); // 防重复请求的 ref

  useEffect(() => {
    // 修复方式1：在 useEffect 内部使用 async/await（推荐）
    const loadData = async () => {
      if (flag.current) {
        flag.current = false;
        const response = await getAllBlogs();
        setData(response.data)

        console.log("loadData--",data);
        
        return response;
      }
    };

    loadData();
  }, []);

  //可以观察到data数据已经更新了，setData但不是实时的
  //   useEffect(() => {
  //     console.log("data 已更新:", data);
  // }, [data]);

  
  // 生成所有数据
  //allData其实已经调用过一次了，但是data是[]
  const allData = useMemo(() => {
    console.log("allData--",data);
    
    return data.map(item => ({
      id:item.id,
      title: item.title,
      description: item.description,
      content: item.content
    }));
  }, [data]);

  // 根据当前页码计算要显示的数据
  const currentData = useMemo(() => {
    const startIndex = (currentPage - 1) * PAGE_SIZE;
    const endIndex = startIndex + PAGE_SIZE;
    return allData.slice(startIndex, endIndex);
  }, [allData, currentPage]);

  // 处理页码变化
  const handlePageChange = (page: number) => {
    setCurrentPage(page);
    // 如果需要，可以在这里滚动到顶部
    // window.scrollTo(0, 0);
  };



  return (


    <>    
   
    {/* <Card title="" extra={<Button>获取成为超级管理员</Button>} style={{ width: 300}}>
      <Avatar size={64} icon={<UserOutlined />} />
      <p>Card content</p>
      <p>Card content</p>
      <p>Card content</p>
    </Card> */}
    
      <div>设置成为超级管理员</div>
      {currentData.map((item) => (
        <Card key={item.id} size="small" title={item.title} extra={<a href={"/content/" + item.id}>查看详情 </a>} style={{ width: '40%', margin: "5px 0" }}>
          <p>{item.description}</p>
        </Card>
      ))}
      
      <Pagination
        current={currentPage}
        defaultCurrent={1}
        total={data.length}
        pageSize={PAGE_SIZE}
        onChange={handlePageChange}
        showSizeChanger={false} // 如果需要每页数量选择器可以设为true
        style={{ marginTop: 16 }}
      />
    
    </>
    
  );
};

export default LayoutPage;