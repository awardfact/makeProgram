const fs = require('fs');

setInterval(()=>{
    fs.unlink('./dasdweqwd', (err)=>{
        if(err){
            console.error(err);
        }


    });


},1000);