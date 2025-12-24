declare namespace API {

  export type Resp<TData> = {
    code: string
    data: TData,
    message:string
  };

    export type PagedResp<TData> = {
      success: boolean
      data: TData[],
      errorCode: string,
      errorMessage: string,
  };

  // export type BlogDto = {
  //   id: number;
  //   title: string;
  //   description: string;
  //   content: string;
  //   authorId: number;
  //   tags: string[];
  // };

  // export type CreateBlogRequest = {
  //   title: string;
  //   description: string;
  //   content: string;
  //   tags: string[];
  // };
}