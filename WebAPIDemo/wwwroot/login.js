const loginform = document.querySelector(".login__form");


loginform.addEventListener('submit', (e) => {
    e.preventDefault(); // for development purposes
    const firstName = loginform.fname
    const lastName = loginform.lname

    const userData = { FirstName: firstName.value, LastName: lastName.value}
   

    fetch('api/Customers/Login', {
        method: 'POST',
        headers: {
            "Accept": 'application/json',
            "Content-Type": "application/json"\
           
        },
        body: {
            "client_id": "CQBhCCcyXItL7YQVhEB8x1BG1OQ5S6gr",
            "client_secret": "9qLFoYey1N5hayuN4vea56tqU0DfrCDKfEZxhSDkvSdEN5TrfL3Jibme5V_cN0A8",
            "audience": "https://swordspell/api",
            "grant_type": "client_credentials"

            https://dev-16fan1ey.us.auth0.com/authorize?
                response_type = code | token &
                client_id=CQBhCCcyXItL7YQVhEB8x1BG1OQ5S6gr&
            connection=CONNECTION&
        redirect_uri=https://YOUR_APP/callback&
        state = STATE
        }


    })
        .then(res => {
            if (!res.ok) {
                console.log('Not ok')
                throw new Error(`Network response was not ok (${res.status})`)
            }
            else
            {
                
                return res.json()
            }
           
        })
        .then(data => {
            console.log(data)
            //var results = document.getElementById('results')
            var results = document.getElementById('login--container')
            var noUser = "Not a user"
            if (data.firstName.localeCompare(noUser) == 0) {

                results.innerHTML = `<h2> ${data.firstName} </br>  ${data.lastName}</h2>`
            }
            else
            {
                //var user = { customerId: `${data.customerId}` }
                sessionStorage.clear()
                sessionStorage.setItem('user', JSON.stringify(data));
                var obj = JSON.parse(sessionStorage.getItem('user'));
                console.log(`session storage object: ${obj}`)
                results.innerHTML = `<h2> Thank you for logging in ${data.firstName} </h2>`

                setTimeout(function () {
                    window.location.href = "store.html"
                }, 3000)
            }

            
        //    
        //    //JSON.parse(sessionStorage.getItem('id'))
        //    //store the info in sessionStorage must be strings
        //    //store cart object on local storage must be strings
            
        })
        .catch(err => console.log(`There was an error ${err}`))
        //.then(res => {
        //    if (!res.ok) {
        //        console.log('Not ok')
        //        throw new Error(`Network response was not ok (${res.status})`)
        //    }
        //    res.json()
        //    return res;
        //})
        //.then(data => {
        //    console.log(data)
        //    //sessionStorage.setItem('id', JSON.stringify(res));
        //    //let id = sessionStorage.getItem('id')
        //    //console.log(id)
        //    //JSON.parse(sessionStorage.getItem('id'))
        //    //store the info in sessionStorage must be strings
        //    //store cart object on local storage must be strings
        //})
        //.catch(err => console.log(`There was an error ${err}`))
})

//use sessionstorage.clear to clean out the session storage can be used at logout
//sessionstorage.removeitem to get rid of just one