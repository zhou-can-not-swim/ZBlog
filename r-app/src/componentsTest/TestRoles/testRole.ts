//接口+泛型
import request from "umi-request";

// 后端登录
export async function testRolePublic() {
  return request('http://localhost:5000/api/test/public', {
    method: 'GET',
    headers: {
      'Content-Type': 'application/json',
    },
   
  });
}

export async function testRolePrivate() {
    // 从 localStorage 获取 token
  const token = localStorage.getItem('token');
  
  if (!token) {
    throw new Error('未登录，请先登录');
  }
  return request('http://localhost:5000/api/test/private', {
    method: 'GET',
    headers: {
        
      'Content-Type': 'application/json',
      'Authorization': `Bearer ${token}`
    },
  });
}