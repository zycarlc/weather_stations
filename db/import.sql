CREATE DATABASE weather;

CREATE TABLE stations (
    id serial,
    ws_name text,
    site text,
    portfolio text,
    state text,
    latitude numeric(10,7),
    longitude numeric(10,7)
);

COPY stations(id, ws_name, site, portfolio, state, latitude, longitude )
FROM '/Users/zhenyuc/Downloads/proa_sample_data/weather_stations.csv'
DELIMITER ','
CSV HEADER;

CREATE TABLE stations (
    var_id PRIMARY KEY,
    id text,
    site text,
    portfolio text,
    state text,
    latitude numeric(10,7),
    longitude numeric(10,7)
);