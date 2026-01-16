import React, { useState, useMemo, useEffect, useRef } from 'react';
import { Avatar, Button, Card, Col, Descriptions, List, Row, Space } from 'antd';
import "./index.css"

import { Flex, Radio, Pagination } from 'antd';
import { getAllBlogs } from '../../services/blogs';
import { getProfile, login } from '@/services/account';
import { deleteBlog } from '@/services/blogs.axios';

const LayoutPage: React.FC = () => {
  const PAGE_SIZE = 5; // 每页显示的数量
  const [currentPage, setCurrentPage] = useState(1); // 当前页码
  const [data, setData] = useState<BlogApi.BlogItem[]>([])

  const flag = useRef(true); // 防重复请求的 ref

  useEffect(() => {
    const loadData = async () => {
      if (flag.current) {
        flag.current = false;
        const response = await getAllBlogs();
        setData(response.data)
        return response;
      }
    };
    loadData();
  }, []);

  const allData = useMemo(() => {
    return data.map(item => ({
      id: item.id,
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

  //获取管理员权限

  const [role, setRole] = useState('')
  
  useEffect(() => {
    const token = localStorage.getItem("token")
    if (token != null) {
      const getAdminRole = async () => {
        var result = await getProfile()
        // console.log(result.username);

        setRole(result.username || '')
        return result;

      }

      getAdminRole()
    }


  }, [])
  // 删除一个blog
  const handleDelete=async (id: number)=>{
    let result=await deleteBlog({id});
    console.log(result);
    
  }

  return (
    <>
      <div className='pageBox'>
        <div className='Card-Avatar-left'>

        </div>

        <div className='Content-right'>
          {currentData.map((item) => (
            <Card key={item.id} size="small" title={item.title} extra={
              <div>
                {role === "admin" ? 
                <>
                  <a href={"/admin/update/" + item.id}>编辑</a>
                  <span>&nbsp;&nbsp;&nbsp;</span>
                  <a href={"#"} onClick={()=>handleDelete(item.id)}>删除</a>    
                </>
                  : ""}
                <span>&nbsp;&nbsp;&nbsp;</span>
                <a href={"/content/" + item.id}>查看详情 </a>
              </div>
            } style={{ width: '60%', margin: "5px" }}>
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
            style={{ marginTop: 16, marginBottom: 10 }}
          />

        </div>
      </div>



    </>

  );
};

export default LayoutPage; 