const url = require('url');

const querystring = require('querystring');

const parseUrl = url.parse('https://github.com/awardfact/makeProgram/tree/master/node?page=3&limit=10&category=nodejs&category=javascript');

const query = querystring.parse(parseUrl.query);


console.log(parseUrl);
console.log('querystring.parse() :' , query);
console.log('querystring.stringify() : ' , querystring.stringify(query));
