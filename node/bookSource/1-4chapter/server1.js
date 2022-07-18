const http = require('http');


http.createServer((req,res)=>{
    res.writeHead(200, {'Content-type' : 'text/html; charset=utf-8' });
    res.write('<div>hello world</div>');
    res.end('<div>hello Server</div>');

}).listen(8080 , ()=>{
    console.log('8080포트');


});