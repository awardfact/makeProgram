setInterval(()=>{
    console.log('start');
    try{
        throw new Error('에러러러');
    }catch(err){
        console.error(err);
    }


} , 1000);