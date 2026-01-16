import { Outlet } from "react-router-dom";

const ErrorPage: React.FC = () => {
    return(
        <>
            <Outlet></Outlet>
        </>
    )
}

export default ErrorPage;