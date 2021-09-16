var div = document.getElementsByClassName('store__conatianer')

async function GetStoreInventory() {
    const response = await fetch('api/Products/Inventory')
    const product = await response.json();
    return product;
}

document.addEventListener("DOMContentLoaded", async () => {
    let product = [];
   

    try {
        GetStoreInventory()
        for (var element = 0; element < product.length; element++){
            div.innerHTML += `<p> ${product[element]}`
        }
        
    }
    catch (e) {
        console.log("Error!")
        console.log(e);
    }

    console.log(product);
    
})

