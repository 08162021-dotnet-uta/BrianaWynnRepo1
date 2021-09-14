const customerList = document.querySelector(".viewCustomers");

customerList.addEventListener("click", getCustomers);

function getCustomers(e ) {
    e.stopPropagation();
    fetch('https://localhost:44350/api/Customers/GetAllCustomers')
        .then(res => res.json())
        .then(data => console.log(data))

};

