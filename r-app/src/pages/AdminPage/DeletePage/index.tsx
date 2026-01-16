import { useParams } from "react-router-dom";

const DeletePage: React.FC = () => {
    const { id } = useParams<{ id: string }>();
    return(
        <></>
    )
    
}

export default DeletePage;