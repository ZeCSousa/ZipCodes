import React from "react";
import Card from '@mui/material/Card';
import CardContent from '@mui/material/CardContent';
import Typography from '@mui/material/Typography';

export function CityCards(response) {


		const codes = response.map(element => {
			return (
				<Card sx={{ minWidth: 275 }}>
					<CardContent>
						<Typography sx={{ fontSize: 14 }} color="text.secondary" gutterBottom>
							Post code
						</Typography>
						<Typography variant="h5" component="div">
							{element["post code"]}
						</Typography>
					</CardContent>
				</Card>);
		});

		return codes;

}
