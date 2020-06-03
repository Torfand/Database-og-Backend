function show() {
         
    html = `
           <input type="text" id="name" name="Name" placeholder="Enter your Name here"/>
           <input type="text" id="email" name="Email" placeholder="Enter your Email here"/>
              <button onclick="getValues()">Click me to subscribe!` ;
    output.innerHTML += html;

    
}