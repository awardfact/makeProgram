const util = require('util');
const crypto = require('crypto');

const dontUsMe = util.deprecate((x,y) =>{
    console.log(x+y);

} , '더이상사용하지마세요!');

dontUsMe(1,2);

const randomBytesPromise = util.promisify(crypto.randomBytes);
randomBytesPromise(64).then((buf) =>{
    console.log(buf.toString('base64'));
}).catch((error)=>{
    console.error(error);
});