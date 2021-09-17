//var div = document.querySelector(".product__conatianer")
var h2storenames = document.querySelectorAll(".stores__card h2")
var pstorelocation = document.querySelectorAll(".stores__card p")
let storeOneBtn = document.getElementById("store--1")
let storeTwoBtn = document.getElementById("store--2")
let storeThreeBtn = document.getElementById("store--3")

let buttons = [ storeOneBtn ,  storeTwoBtn ,  storeTwoBtn ]


//async function GetStoreInventory() {
//    const response = await fetch('api/Products/Inventory')
//    const product = await response.json();
//    return product;
//}

let STORES = [];
async function GetStores() {
    const response = await fetch('api/Store/Store')
    const store = await response.json()
    STORES = store;
    return store;
}


document.addEventListener("DOMContentLoaded", async () => {
    let store = [];
    try {
        store = await GetStores()
        for (var i = 0; i < store.length; i++) {
            h2storenames[i].innerHTML = store[i].name
            pstorelocation[i].innerHTML = store[i].address
            buttons[i].setAttribute('data-id', store[i].storeId);
            buttons[i].addEventListener('click', sendToStorage);
        }
    }
    catch (e) {
        console.log("Error!")
        console.log(e);
    }

    console.log(store);

})

async function sendToStorage(e) {
    e.preventDefault();
    let id = parseInt(e.target.getAttribute('data-id'));
    console.log('shopping at store:', id);
    let _store = JSON.stringify(STORES[id -1]);
    await localStorage.setItem('Store.Key', _store);
}

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

