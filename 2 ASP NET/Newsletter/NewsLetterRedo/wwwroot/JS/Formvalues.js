function getValues() {

    const name = document.getElementById("name").value;
    const email = document.getElementById("email").value;
    if (!name || !email)return alert("Fields need values");
        
     subscribe(name, email);
}