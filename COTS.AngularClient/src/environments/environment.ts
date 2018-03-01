// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

//var _serverHost = "http://localhost:59837";
var _serverHost = "http://diplomproject.azurewebsites.net/";
var _slash = "/";
export const environment = {
  production: false,

  //webApi
  APIURL_MOVIE :                              _serverHost +  "/api/movie/",
  APIURL_MOVIES_PREMERIES_BYCITY :            _serverHost +  "/api/movie/premeries/",
  APIURL_MOVIES_COMINGSOON_BYCITY :           _serverHost +  "/api/movie/comingsoon/",
  APIURL_MOVIES_TOP10_BYCITY :                _serverHost +  "/api/movie/top10/",

  APIURL_CINEMA :                             _serverHost +  "/api/cinema/",
  APIURL_CINEMAS_BYCITY:                      _serverHost +  "/api/cinema/getallbycity/",

  APIURL_PLACES_BY_CITY_CINEMA_HALL_SEANCE:   _serverHost + "/api/place/getall/",

  APIURL_CITIES:                              _serverHost +  "/api/city/getall",

  APIURL_SEANCES_BY_CINEMA_MOVIE_DATE:        _serverHost +  "/api/seance/getall/",
  APIURL_SEANCE:                              _serverHost + "/api/seance/",

  APIURL_TICKETS_BY_PURCHASE:                 _serverHost +  "/api/ticket/by_purchase/",
  APIURL_TICKETS_GETALL:                      _serverHost + "/api/ticket/getall",

  APIURL_PURCHASE_SAVE_IN_DB:                 _serverHost +  "/api/purchase/save_in_db",  
  APIURL_PURCHASE:                            _serverHost +  "/api/purchase/",
  APIURL_PURCHASE_UPDATE:                     _serverHost +  "/api/purchase/update",
  APIURL_PURCHASE_REMOVE:                     _serverHost +  "/api/purchase/remove/",

  APIURL_SECTORS_BY_ENTERTAIMENT:             _serverHost +  "/api/sector/getall/",

  APIURL_USER_IS_EXIST:                       _serverHost + "/api/user/is_exist",
  APIURL_USER:                                _serverHost + "/api/user/",
};
