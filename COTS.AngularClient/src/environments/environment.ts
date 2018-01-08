// The file contents for the current environment will overwrite these during build.
// The build system defaults to the dev environment which uses `environment.ts`, but if you do
// `ng build --env=prod` then `environment.prod.ts` will be used instead.
// The list of which env maps to which file can be found in `.angular-cli.json`.

var _serverHost = "http://localhost:59837";
export const environment = {
  production: false,
  APIURL_MOVIE :                     _serverHost +  "/api/movie/",
  APIURL_MOVIES_PREMERIES_BYCITY :   _serverHost +  "/api/movie/premeries/",
  APIURL_MOVIES_COMINGSOON_BYCITY :  _serverHost +  "/api/movie/comingsoon/",
  APIURL_MOVIES_TOP10_BYCITY :       _serverHost +  "/api/movie/top10/",
  APIURL_CINEMA :                    _serverHost +  "/api/cinema/",
  APIURL_CINEMAS_BYCITY:             _serverHost +  "/api/cinema/getallbycity/",
  APIURL_CITIES:                     _serverHost +  "/api/city/getall"
};
