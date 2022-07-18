process.on('uncaughtException', (err)=>{

    console.error('예기치 못한 에러' , err);

});


setInterval(()=>{
    throw new Error('errorr');



},  1000);


setTimeout(()=>{
    console.log('실행');

});