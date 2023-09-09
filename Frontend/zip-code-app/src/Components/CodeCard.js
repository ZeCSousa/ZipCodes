import React from "react";
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import Typography from '@mui/material/Typography';

export function CodeCard(response) {

			return (
				<Card sx={{ minWidth: 275 }}>
					<CardContent>
						<Typography sx={{ fontSize: 14 }} color="text.secondary" gutterBottom>
							Post code
						</Typography>
						<Typography variant="h6" component="div">
							{response["post code"]}
						</Typography>
						<Typography sx={{ fontSize: 14 }} color="text.secondary" gutterBottom>
							Country
						</Typography>
						<Typography variant="h6" component="div">
							{response["country"]}
						</Typography>
						{enumeratePlaces(response["places"])}
					</CardContent>
				</Card>);
}


const enumeratePlaces = places => {

	const cards = places.map(place => {
		return (
			<Card sx={{ minWidth: 175 }}>
				<CardContent>
					<Typography sx={{ fontSize: 10 }} color="text.secondary" gutterBottom>
						Location:
					</Typography>
					<Typography component="div">
						{place["place name"]}
					</Typography>
					<Typography sx={{ fontSize: 10 }} color="text.secondary" gutterBottom>
						Lonitude:
					</Typography>
					<Typography  component="div">
						{place["longitude"]}
					</Typography>
					<Typography sx={{ fontSize: 10 }} color="text.secondary" gutterBottom>
						Latitude:
					</Typography>
					<Typography component="div">
						{place["latitude"]}
					</Typography>
					<Typography sx={{ fontSize: 10 }} color="text.secondary" gutterBottom>
						State:
					</Typography>
					<Typography  component="div">
						{place["state"]}
					</Typography>
				</CardContent>
			</Card>);
	});
	return cards;
}