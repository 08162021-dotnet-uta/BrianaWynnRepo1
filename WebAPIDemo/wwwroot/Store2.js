//works for printing all available product from all stores to the screen
var div = document.querySelector(".product__conatianer")
var orderDiv = document.querySelector(".order__container")
var storeonebtn = document.getElementById("storeone--btn")


async function GetStoreInventory() {
    const response = await fetch('api/Products/Inventory/2')
    const product = await response.json();
    return product;
}


async function GetStoreOrder() {
    const response = await fetch('api/Store/Order/2')
    const order = await response.json();

    return order;
}

document.addEventListener("DOMContentLoaded", async () => {
    let product = [];


    try {
        product = await GetStoreInventory()
        //console.log('im here')
        //console.log(product[0].name)
        for (var i = 0; i < product.length; i++) {
            div.innerHTML += `<p>${product[i].name}</p>`
        }

    }
    catch (e) {
        console.log("Error!")
        console.log(e);
    }

    console.log(product);

})

storeonebtn.addEventListener("click", async () => {
    let order = [];


    try {
        order = await GetStoreOrder()
        //console.log('im here')
        //console.log(product[0].name)
        for (var i = 0; i < order.length; i++) {
            orderDiv.innerHTML += `<p>${order[i].orderId}</p>`
            orderDiv.innerHTML += `<p>${order[i].firstName}</p>`
            orderDiv.innerHTML += `<p>${order[i].lastName}</p>`
            orderDiv.innerHTML += `<p>${order[i].name}</p>`
            orderDiv.innerHTML += `<p>${order[i].description}</p>`
            orderDiv.innerHTML += `<p>${order[i].price}</p>`
            orderDiv.innerHTML += `<p>${order[i].quantity}</p>`

        }

    }
    catch (e) {
        console.log("Error!")
        console.log(e);
    }

    console.log(order);

})