import React, { useState, useEffect } from "react";
import { Table } from "react-bootstrap";
import ZipCodesRow from "./zip-codes-table-row";

const TopSearches = () => {

const apiEndpoint = "https://localhost:443/api/v1/ZipCodes/GetTopCodes";


const [result, setResult] = useState([]);
const [count, setCount] = useState(10);

useEffect(() => {
	fetch(`${apiEndpoint}?top=${count}`)
		.then((response) => response.json()) // parse the response as JSON
		.then((data) => {
		  setResult(data); // set the result state
		})
		.catch((error) => {
		  console.error(error); // handle any errors
		});
}, []);

const DataTable = () => 	
	 result.map((res, i) => {
	return <ZipCodesRow obj={res} key={i} />;
	});


return (
	<div className="table-wrapper">
		 {result.length ?
	<Table striped bordered hover>
		<thead>
		<tr>
			<th>Code</th>
			<th>Country</th>
			<th>Search Count</th>
		</tr>
		</thead>
		<tbody>{DataTable()}</tbody>
	</Table>
	: "No Content yet."
	} 
	
	</div>
);
};

export default TopSearches;
