import { React } from 'react';
import { Select, message } from 'antd';

const { Option } = Select;

const JobPositionStatusDropwdown = ({ currentStatus }) => {

    const statusList = [
        "Applied",
        "In review",
        "Not accepted",
        "Accepted!"
    ]

    function handleChange(newStatus) {
        message.info(`Status changed to ${newStatus}`);
    }

    return (
        <Select defaultValue={currentStatus} onChange={handleChange} style={{ width: 180 }}>
            {statusList.map((status) =>
                <Option value={status}> {status} </Option>
            )}
        </Select>
    )
}

export default JobPositionStatusDropwdown;