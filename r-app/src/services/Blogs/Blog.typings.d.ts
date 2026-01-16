// 后端实体的属性

declare namespace BlogApi
{
    export enum BlogStatus {
        Draft = 0,
        Published = 1,
        Deleted = 999,
    }
    
    export type BlogAuthor = {
        id: number,
        name: string,
        email: string,
    }

    export type BlogItem = {
        authorId:number,
        content:string,
        description:string,
        id:number,
        tags:number[],
        title:string
    }
}