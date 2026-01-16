

export namespace API {
  export type FieldType = {
    username?: string;
    password?: string;
    remember?: string;
  };

  export type AccountProfile={
    username?: string;
    email?:string;
    createAt?:string
  }
}