import EditMd from "@/components/EditMd";
import UpdateMd from "@/components/UpdateMd";
import { useParams } from "react-router-dom";

const UpdatePage: React.FC = () => {
    const { id } = useParams<{ id: string }>();
    return(
    <UpdateMd blogId={id}></UpdateMd>)
}

export default UpdatePage;