//var div = document.querySelector(".product__conatianer")
var h2storenames = document.querySelectorAll(".stores__card h2")
var pstorelocation = document.querySelectorAll(".stores__card p")

//async function GetStoreInventory() {
//    const response = await fetch('api/Products/Inventory')
//    const product = await response.json();
//    return product;
//}

async function GetStores() {
    const response = await fetch('api/Store/Store')
    const store = await response.json()
    return store;
}


document.addEventListener("DOMContentLoaded", async () => {
    let store = [];
    try {
        store = await GetStores()
        for (var i = 0; i < store.length; i++) {
            h2storenames[i].innerHTML = store[i].name
            pstorelocation[i].innerHTML = store[i].address
        }
    }
    catch (e) {
        console.log("Error!")
        console.log(e);
    }

    console.log(store);

})

///works for printing all available product from all stores to the screen
//document.addEventListener("DOMContentLoaded", async () => {
//    let product = [];
   

//    try {
//        product = await GetStoreInventory()
//        //console.log('im here')
//        //console.log(product[0].name)
//        for (var i = 0; i < product.length; i++){
//            div.innerHTML += `<p>${product[i].name}</p>`
//         }
        
//    }
//    catch (e) {
//        console.log("Error!")
//        console.log(e);
//    }

//    console.log(product);
    
//})

