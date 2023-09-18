import React from "react";

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
