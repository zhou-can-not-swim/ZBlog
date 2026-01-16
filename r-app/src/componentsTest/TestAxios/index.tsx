import { Button, Card, Empty } from "antd";
import { useEffect, useMemo, useState } from "react";
import request from "umi-request";
import { log } from "node:console";
import { getTagsList } from "@/services/tags";

const TestAxios = () => {

    const [list,setList] = useState<TagApi.TagItem[]>([])
    useEffect(() => {
        const getAllList = async () => {
            const v = await getTagsList();
            setList(v)

            console.log(v);
            console.log(list);
            console.log(v);
            
            return v;
        }
        getAllList()
    }, [])

    // useEffect(() => {
    // console.log("useEffect--list--", list);
    // }, [list])

    return (
        <div>
            测试axios界面
            {list.length === 0 ? (
                <Empty description="暂无数据" />
            ) : (
                <ul>
                    {list.map((item) => (
                        <li key={item.id}>
                            {item.id}
                            {item.name}
                        </li>
                    ))}
                </ul>
            )}
        </div>
    );
};
export default TestAxios;