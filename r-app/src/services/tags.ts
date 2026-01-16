// //接口+泛型
// import request from "umi-request";


// /** 获取所有博客 GET /api/blog */
// export async function getAllBlogs() {

//   return await request('http://localhost:5000/api/blog/all', {
//     method: 'GET',
//     // params,
//     // ...(options || {}),
//   });
// }

import request from "@/utils/request";

export async function getTagsList() {
  const resposne= await request.get("/tag/all");
  return resposne;
}