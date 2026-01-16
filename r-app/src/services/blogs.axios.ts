import request from "@/utils/request";

//通过id找blog
export async function findOneBlog(params: {id: string|undefined}, options?: {[key:string]: any})
{
    return await request.get<BlogApi.BlogItem>('/blog/', params);
}

export async function updateBlog(req: {id?:string,title?:string,description?:string,content?: string,tagIds?:number[]}, options?: {[key:string]: any})
{
    return await request.post('/blog/update',req);
}


export async function deleteBlog(req: {id?:number}, options?: {[key:string]: any})
{
    return await request.get('/blog/delete',req);
}
