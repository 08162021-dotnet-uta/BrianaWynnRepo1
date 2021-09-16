const loginform = document.querySelector(".login__form");

loginform.addEventListener('submit', (e) => {
    e.preventDefault(); // for development purposes
    const userEmail = loginform.userEmail.value
    const userPassword = loginform.userPassword.value
   

    fetch(`Customers/login/${userEmail}/${userPassword}`)
        .then(res => {
            if (!res.ok) {
                console.log('Not ok')
                throw new Error(`Network response was not ok (${res.status})`)
            }
            res.json()
            return res;
        })
        .then(data => {
            console.log(data)
            sessionStorage.setItem('id', JSON.stringify(res));
            let id = sessionStorage.getItem('id')
            console.log(id)
            //JSON.parse(sessionStorage.getItem('id'))
            //store the info in sessionStorage must be strings
            //store cart object on local storage must be strings
        })
        .catch(err => console.log(`There was an error ${err}`))
})

//use sessionstorage.clear to clean out the session storage can be used at logout
//sessionstorage.removeitem to get rid of just one