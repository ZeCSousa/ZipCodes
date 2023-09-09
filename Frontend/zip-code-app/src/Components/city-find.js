import React, { useState } from "react";

import { CityCards } from "./CityCards";


const CityFind = () => {

	const apiEndpoint = "https://localhost:64544/api/v1/ZipCodes/getByCity";


	const [city, setCity] = useState("");
	const [country, setCountry] = useState("");
	const [result, setResult] = useState([]);
  
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
	  fetch(`${apiEndpoint}/${country}/${city}`)
		.then((response) => response.json()) // parse the response as JSON
		.then((data) => {
		  setResult(data); // set the result state
		})
		.catch((error) => {
		  console.error(error); // handle any errors
		});
	};
  
	const handleClearClick = () => {
	  // reset the input values and the result state
	  setCity("");
	  setCountry("");
	  setResult(null);
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
		  <label htmlFor="country">Country:</label>
			<input
			  type="text"
			  id="country"
			  name="country"
			  value={country}
			  onChange={handleCountryChange}
			/>
		  <div className="search-form">
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
