var form = document.getElementById('registration--form')

//var fname = form.FirstName
var fname = document.getElementById('fname')
var lname = document.getElementById('lname')
var email = document.getElementById('useremail')
var password = document.getElementById('userpassword')
var results = document.getElementById('results')

form.addEventListener('submit', ValidateUserInfo)


function ValidateUserInfo(e) {
    e.preventDefault()
    
    let messages = []
    //check that name meets requirements
    if (fname.value.length > 50 || lname.value.length > 50) {
        
        messages.push('Name must be less than 50 characters')
    }
    //check that password meets requirements
    if (password.value.length <= 6) {
        messages.push('Password must be greater than 6 characters')
    }

    //html validates email for us;
    
    //output the error messages to screen stop the form from submitting
    if (messages.length > 0) {

        alert(`${messages.join('\n')}`);
       
    }
    else {
        addUser();
    }

}



function addUser() {
    const userData = { firstName: fname.value, lastName: lname.value, email: email.value, pWord: password.value }
    //ValidateUserInfo(e);
    //e.stopPropagation()
    //e.preventDefault()
   
   // ValidateUserInfo(e)

    //now make the fetch post request
    fetch('https://dev-16fan1ey.us.auth0.com/oauth/token', {
        method: 'POST',
        headers: {
            "Accept": 'application/json',
            "Content-Type": "application/json"
        },           
        body: 


    })
        .then(res => {
            return res.json()
        })
        .then(data => {
            console.log(data)
            var results = document.getElementById('results')
            var login = document.getElementById('buttonAppear')
            results.innerHTML = `<h2> Thank You For Registering ${fname.value}</h2>`
            results.innerHTML += '<h2> Please Login </h2>'
            login.innerHTML = '<button class="main__btn" id="register_user"><a href="login.html">Login</a> </button>'
        })

}

