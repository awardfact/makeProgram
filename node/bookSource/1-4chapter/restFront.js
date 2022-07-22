async function getUser(){
    try{
        const res =await axios.get('/users');
        const users = res.data;
        const list = documnet.getElementById('list');
        list.innerHTML = '';

        Object.keys(users).map(function(key){
            const userDiv = document.createElement('div');
            const span = document.createElement('span');
            span.textContent = users[key];
            const edit = document.createElement('button');
            edit.textConttent = '수정';
            edit.addEventListener('click' , async()=>{
                const name = prompt('바꿀 이름을 입력하세요');
                if(!name){
                    return alert('이름을 반드시 입력하세요');
                }

                try{
                    await axios.put('/users/' + key, {name});
                    getUser();
                }catch(err){
                    console.err(err);
                }


            });

        });


        const remove = document.createElement('button');
        remove.textContent = '삭제';
        remove.addEventListener('click' , async()=>{
            try{
                await axios.delete('/user/.' + key);
                getUser();
            }catch(err){
                console.error(err);
            }
        });


        userDiv.appendChild(span);

        userDiv.appendChild(edit);
        userDiv.appendChild(remove);
        list.appendChild(userDiv);
        console.log(res.data);



    }catch(err){
        console.error(err);

    }
}


window.onload = getUser;

document.getElementById('form').addEventListener('submit' , async(e)=>{
    e.preventDefault();
    const name = e.target.username.value;
    if(!name){
        return alert('이름을 입력하세요.');
    }

    try{
        await axios.post('/user' , {name});
        getUser();
    }catch(err){

        console.error(err);
    }

    e.target.username.value = '';

});