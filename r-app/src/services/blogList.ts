// 存放所有的与后端交互的接口

//接口+泛型
import request from "umi-request";
/** 获取所有博客 GET /api/blog */
export async function getAllBlogs(
  // params?: {
  //   // search?: string;
  //   // tags?: string[];
  //   // page?: number;
  //   // pageSize?: number;
  // },
  // options?: { [key: string]: any }
) {
  //<API.Resp<BlogApi.BlogItem[]>>
  return await request('http://localhost:5031/api/blog/all', {
    method: 'GET',
    // params,
    // ...(options || {}),
  });
}

export function findOne(params: {id: string}, options?: {[key:string]: any})
{
    return request('/api/traces/traceinfo/Find',{
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
        },
        params: params,
        ...(options || {})
    });
}

// var s = await removeProdBomItem({ traceInfoId: props.item.traceInfoId, bomItemId: props.item.id })
export function removeProdBomItem(req: {traceInfoId: string; bomItemId: string}, options?: {[key:string]: any})
{
    return request('/api/traces/traceinfo/RemoveBomItem',{
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        data: req,
        ...(options || {})
    });
}