if (location.search.includes("email") && location.search.includes("code")) {

    getURL();
}

function getURL() {
    
    const urlParam = new URLSearchParams(location.search);
    console.log(urlParam);
    if (location.search.includes("email") && location.search.includes("code")) {
        const email = urlParam.get("email");
        const code = urlParam.get("code");
        verify(email, code);
    }
    async function verify(email, code) {
        await axios.put('api/verify', { email, code })
            .then(res => {
                console.log(res)
            })
            .catch(err => {
                console.error(err);
            })
        html = '<h1>VERIFIED</h1>';
        output.innerHTML = html;
    }
}