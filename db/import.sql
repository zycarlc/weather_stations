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

CREATE TABLE weather_data (
    id serial,
    station_id int,
    timestamp timestamp,
    AirT_inst numeric(10,2),
    GHI_inist float,
    avg_Wm2 numeric(10,1),
    avg_airTemp numeric(10,2),
    WS_avg numeric(10,3),
    WD_avg numeric(10,1)
);

COPY weather_data(station_id, timestamp, AirT_inst, GHI_inist, avg_Wm2, avg_airTemp, WS_avg, WD_avg )
FROM '/Users/zhenyuc/Downloads/Untitled spreadsheet - Sheet1.csv'
DELIMITER ','
CSV HEADER;