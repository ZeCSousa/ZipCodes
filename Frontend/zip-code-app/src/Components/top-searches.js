import React, { useState, useEffect } from "react";
import axios from "axios";
import { Table } from "react-bootstrap";
import ZipCodesRow from "./zip-codes-table-row";

const TopSearches = () => {
const [Agents, setAgents] = useState([]);

useEffect(() => {
	axios
	.get("http://localhost:8080/agents/")
	.then(({ data }) => {
		setAgents(data);
	})
	.catch((error) => {
		console.log(error);
	});
}, []);

const DataTable = () => {
	return Agents.map((res, i) => {
	return <ZipCodesRow obj={res} key={i} />;
	});
};

return (
	<div className="table-wrapper">
	<Table striped bordered hover>
		<thead>
		<tr>
			<th>Code</th>
			<th>City</th>
			<th>Country</th>
		</tr>
		</thead>
		<tbody>{DataTable()}</tbody>
	</Table>
	</div>
);
};

export default TopSearches;
