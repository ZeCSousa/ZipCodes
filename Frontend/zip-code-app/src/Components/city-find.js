import React, { useState } from "react";

import { CityCards } from "./CityCards";
import { fetchWithTimeout } from "../utils";


const CityFind = () => {

	const apiEndpoint = "https://localhost:443/api/v1/ZipCodes/getByCity";


	const [city, setCity] = useState("");
	const [country, setCountry] = useState("");
	const [result, setResult] = useState([]);
	const [error, setError] = useState(false);
  
	// handle the change events of the inputs
	const handleCityChange = (event) => {
	  setCity(event.target.value);
	};
  
	const handleCountryChange = (event) => {
	  setCountry(event.target.value);
	};
  
	// handle the click events of the buttons
	const handleSearchClick = () => {
	  // use the props.api as the external API endpoint
	  // use the city and country as the query parameters
	  fetchWithTimeout(`${apiEndpoint}/${country}/${city}`, { method: "GET" }, 5000)
		.then((response) => response.json()) // parse the response as JSON
		.then((data) => {
		  setResult(data); // set the result state
		  setError(false);
		})
		.catch((error) => {
		  console.error(error); // handle any errors
		 setError(true);
		});
	};
  
	const handleClearClick = () => {
	  // reset the input values and the result state
	  setCity("");
	  setCountry("");
	  setResult(null);
	  setError(false);
	};




 const cardsWithHeader = (result) => {

	const cityName = result[0]["places"][0]["place name"];
	const cityState = result[0]["places"][0]["state"];

	return (
		<div>
           <p>Post Codes for { cityName}s, state of {cityState}:</p>
			{ CityCards(result)}
</div>
	)
 } 

	  return (
		<div className="search-page">
		  <h3>Search City</h3>
		  <div className="search-form">
		  <label htmlFor="country">Country:</label>
			<input
			  type="text"
			  id="country"
			  name="country"
			  value={country}
			  onChange={handleCountryChange}
			/>
	
			<label htmlFor="city">City Name:</label>
			<input
			  type="text"
			  id="city"
			  name="city"
			  value={city}
			  onChange={handleCityChange}
			/>	
			
			<button onClick={handleSearchClick}>Search</button>
			<button onClick={handleClearClick}>Clear</button>
			
	
		  </div>
		 {error && <p>Error fetching results.</p>}
		  <div className="search-result">
			{(result.length > 0) ? ( // if result is not null, show it in a paragraph
			 cardsWithHeader(result)
			) : (
			  // if result is null, show a placeholder message
			  <p>No result yet.</p>
			)}
		  </div>
		</div>
	  );
};

export default CityFind;
