import { Button } from "antd";
import { useEffect } from "react";
import request from "umi-request";
import { testRolePrivate, testRolePublic } from "./testRole";
import { log } from "node:console";

const TestRoles = () => {
  
    const testPublic=async ()=>{
        let result=await testRolePublic();
        console.log(result);
        
        
    }

    const testPrivate=async ()=>{
        let result=await testRolePrivate();
        console.log(result);
        
    }
    return (
        <div>
            <Button onClick={testPublic} type="primary">Public</Button>
            <Button onClick={testPrivate} type="primary">Private</Button>
        </div>
    );
};
export default TestRoles;