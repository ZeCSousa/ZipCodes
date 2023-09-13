import React from "react";
import { Button } from "react-bootstrap";
import { Link } from "react-router-dom";
import axios from "axios";

const ZipCodesRow = (props) => {
	const { code, country, searches } = props.obj;

	return (
		<tr>
			<td>{code}</td>
			<td>{country}</td>
			<td>{searches}</td>
		</tr>
	);
};

export default ZipCodesRow;
