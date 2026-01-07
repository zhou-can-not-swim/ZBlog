//接口+泛型
import request from "umi-request";

// 后端登录
export async function login(body: AccountApi.User, options?: { [key: string]: any }) {
  return request('http://localhost:5000/api/Account/login', {
    method: 'POST',
    headers: {
      'Content-Type': 'application/json',
    },
    data: body,
    ...(options || {}),
  });
}

