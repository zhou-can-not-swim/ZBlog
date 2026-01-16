// ContentPage.tsx
import React, { useEffect, useMemo, useState } from 'react';
import { useParams } from 'react-router-dom';
import { findOne } from '../../services/blogs';
import MarkD from "../../components/MdPreView/index"

const ContentPage: React.FC = () => { // 移除 async 关键字
  const { id } = useParams<{ id: string }>();
  const [blog, setBlog] = useState<BlogApi.BlogItem>(); // 定义状态存储数据
  const [loading, setLoading] = useState(true); // 加载状态
  // 异步获取数据（客户端执行）
  useEffect(() => {
    const fetchBlog = async () => {
      if (!id) return; // 避免 id 为空时请求
      try {
        const data = await findOne({ id });
        setBlog(data.data);
        console.log("fetchBlog--", blog);

      } catch (error) {
        console.error('获取博客失败：', error);
      } finally {
        setLoading(false);
      }

    };

    fetchBlog();
  }, []); // 依赖 id，id 变化时重新请求

  useEffect(() => {
    console.log("useEffect--blog--", blog);
  }, [blog])


  const data = useMemo(() => {
    // 若 blog 未加载完成，返回默认值
    if (!blog) {
      return {
        title: '默认标题',
        content: ''
      };
    }
    // blog 存在时处理数据
    return {
      title: blog.title || '无标题', // 加兜底，避免 title 为空
      content: blog.content || '' // 可根据需求处理 content
    };
  }, [blog]); // 依赖 blog，仅当 blog 变化时重新计算


  if (loading) return <div>加载中...</div>;

  // 这个界面是预览界面
  return (
      <MarkD blogDetail={{title:data?.title,content:data?.content}} ></MarkD>
  );
};

export default ContentPage;
