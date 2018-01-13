// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

var _serverHost = "http://localhost:59837";
var _slash = "/";
export const environment = {
  production: false,

  //webApi
  APIURL_MOVIE :                        _serverHost +  "/api/movie/",
  APIURL_MOVIES_PREMERIES_BYCITY :       _serverHost +  "/api/movie/premeries/",
  APIURL_MOVIES_COMINGSOON_BYCITY :     _serverHost +  "/api/movie/comingsoon/",
  APIURL_MOVIES_TOP10_BYCITY :          _serverHost +  "/api/movie/top10/",

  APIURL_CINEMA :                       _serverHost +  "/api/cinema/",
  APIURL_CINEMAS_BYCITY:                _serverHost +  "/api/cinema/getallbycity/",

  APIURL_CITIES:                        _serverHost +  "/api/city/getall",

  APIURL_SEANCES_BY_CINEMA_MOVIE_DATE:  _serverHost +  "/api/seance/getall/",

  APIURL_TICKETS_SAVE_IN_DB:           _serverHost +  "/api/ticket/save_in_db",
  APIURL_TICKETS_BY_PURCHASE:          _serverHost +  "/api/ticket/by_purchase/",
  APIURL_TICKETS_GET_PURCHASE:         _serverHost +  "/api/ticket/get_purchase/"
};
