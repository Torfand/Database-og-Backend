async function subscribe(name, email) {

    let result = await axios.post('/api/subscribe', { name, email });
    console.log(result);
    let html = `Please check e-mail for activation code`;
    output.innerHTML = html;
    return alert("subscription Sucsessfull");

 
}