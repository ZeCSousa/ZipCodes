# ZipCodes Backend
ZipCodesServer is a small ASPNet Core Web Api that allows to search by zip codes, by city and listing top zip codes (the most searched ones).
This app was built using .Net Core 6 and uses mongo db as database. 

## How it works 
Users can search for a zip code and data will be fetch from an external API (zippopotamus). After searching for some valid zip code, data will be added to a database of known zip codes. This will allow to search those stored zip codes by city or find the most searched zip codes.

## How to setup

## Running using Docker

### `docker-compose up -d zipcodesserver`

Starts app in a container exposing port 80. To find its swagger doc access [https://localhost/swagger/index.html](https://localhost/swagger/index.html).

