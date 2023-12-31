import React, { useState } from "react";


import { CodeCard } from "./CodeCard";
import { fetchWithTimeout } from "../utils";


const ZipCodeFind = () => {

	const apiEndpoint = "https://localhost:443/api/v1/ZipCodes/getByCode";


	const [code, setCode] = useState("");
	const [country, setCountry] = useState("");
	const [result, setResult] = useState(null);
	const [error, setError] = useState(false);
  
	// handle the change events of the inputs
	const handleCityChange = (event) => {
	  setCode(event.target.value);
	};
  
	const handleCountryChange = (event) => {
	  setCountry(event.target.value);
	};
  
	// handle the click events of the buttons
	const handleSearchClick = () => {
	  // use the props.api as the external API endpoint
	  // use the city and country as the query parameters
	  fetchWithTimeout(`${apiEndpoint}/${country}/${code}`, { method: "GET" }, 5000)
		.then((response) => response.json()) // parse the response as JSON
		.then((data) => {
		  setResult(data); // set the result state
		  setError(false);
		})
		.catch((error) => {
		  console.error(error); // handle any errors
		  setResult(null);
		  setError(true)
		});
	};
  
	const handleClearClick = () => {
	  // reset the input values and the result state
	  setCode("");
	  setCountry("");
	  setResult(null);
	};


 const cardsWithHeader = (result) => {

	const cityName = result["places"][0]["place name"];
	const cityState = result["places"][0]["state"];

	return (
		<div>
           <p>Post Codes for { cityName}, state of {cityState}:</p>
			{ CodeCard(result)}
</div>
	)
 } 

	  return (
		<div className="search-page">
		  <h3>Search by Code</h3> 
		   <div className="search-form">
		  <label htmlFor="country">Country:</label>
			<input
			  type="text"
			  id="country"
			  name="country"
			  value={country}
			  onChange={handleCountryChange}
			/>
		
			<label htmlFor="code">Zip Code:</label>
			<input
			  type="text"
			  id="code"
			  name="code"
			  value={code}
			  onChange={handleCityChange}
			/>			
			<button onClick={handleSearchClick}>Search</button>
			<button onClick={handleClearClick}>Clear</button>
		  </div>
		  {error && <p>Error fetching results.</p>}
		  <div className="search-result">
			{result ? ( // if result is not null, show it in a paragraph
			 cardsWithHeader(result)
			) : (
			  // if result is null, show a placeholder message
			  <p>No result yet.</p>
			)}
		  </div>
		</div>
	  );
};

export default ZipCodeFind;

