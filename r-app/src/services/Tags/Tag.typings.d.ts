declare namespace TagApi
{

    export type TagItem = {
        id:number,
        name:string,
        createAt:string,
    }

    export type TagOptions={
        value:number,
        label:string
    }
}