//接口+泛型
// import request from "umi-request";

import request from "@/utils/request";
import { API } from "./Admin/typings";

// 后端登录
export async function login(body: AccountApi.User) {
  const response=await request.post('/Account/login', body);
  return response;
}

export async function getProfile(options?: { [key: string]: any }) {
  return await request.get<API.AccountProfile>('/Account/profile');
}

