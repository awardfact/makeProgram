const { hol , jjak } = require("../var.js");
const checkNumber = require("../func.js");


function checkString(str){
    if(str.length % 2){
        return hol;
    }else{
        return jjak;
    }
}


console.log(checkNumber(10));
console.log(checkString('hello'));