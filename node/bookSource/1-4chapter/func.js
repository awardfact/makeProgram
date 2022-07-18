const { jjak , hol } = require('../var');

function checkHolOrJjak(num){
    if(num % 2){
        return hol;
    }else{
        return jjak;
    }
}


module.export = checkHolOrJjak;