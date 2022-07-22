const http = require('http');


const server = http.createServer((req,res)=>{
    res.writeHead(200, {'Content-type' : 'text/html; charset=utf-8' });
    res.write('<div>hello world</div>');
    res.end('<div>hello Server</div>');

});


server.listen(8080);

server.on('listening' , ()=>{

    console.log('8080포트에서 서버 대기중');
});


server.on('error' , ()=>{
    console.error(error);
});