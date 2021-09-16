//works for printing all available product from all stores to the screen
var div = document.querySelector(".product__conatianer")


async function GetStoreInventory() {
    const response = await fetch('api/Products/Inventory/2')
    const product = await response.json();
    return product;
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