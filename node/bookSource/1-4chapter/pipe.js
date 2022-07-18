const fs = require('fs');

const readStream = fs.createReadStream('./readme4.txt' );
const writeStream = fs.createWriteStream('writeme3.txt');

readStream.pipe(writeStream);


const data = [];

/*
readStream.on('data' , (chunk)=>{
    data.push(chunk);
});

readStream.on('end' , ()=>{
});
readStream.on('error' , (err)=>{
    console.log('error : ' , err);
});


const writeStream = fs.createWriteStream('./writeme5.txt');

writeStream.on('finish', () =>{
    console.log('파일 옮기기 완료');
});

writeStream.write(Buffer.concat(data).toString());
writeStream.end();
*/