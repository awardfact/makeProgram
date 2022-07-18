const timeout = setTimeout(()=>{
    console.log('2초후에 실행');
}, 2000);


const setInter = setInterval( () =>{
    console.log('0.6초마다 실행');
} , 600);


const timeout2 = setTimeout( ()=>{
    console.log('not run');

} , 5000);



setTimeout(()=>{
    clearTimeout(timeout2);
    clearInterval(setInter);
} , 2550);


const imme = setImmediate(()=>{
    console.log('즉시실행');
});

const imme2 = setImmediate(()=>{

console.log('not run 2');
});

clearImmediate(imme2);