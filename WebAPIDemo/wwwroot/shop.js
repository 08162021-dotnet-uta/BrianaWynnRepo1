/*add products to the cards at the bottom of shop page*/
let productname = document.getElementById('h1--featured--product');
let productDescription = document.getElementById('p--featured--product');

async function GetRandomProduct() {
    const response = await fetch('api/Products/Random') 

    const product = await response.json();
    return product;
    
}

async function GetBottomProduct4() {
    const response = await fetch('api/Products/BottomCards')

    const products = await response.json();
    return products;
   
}

document.addEventListener("DOMContentLoaded", async () => {
    let product = [];
    let products = [];

    try {
        product = await GetRandomProduct();
        products = await GetBottomProduct4();
        AddProductToScreen(product)
        AddOtherProductToScreen(products)
    } catch (e) {
        console.log("Error!")
        console.log(e);
    }

    console.log(product);
    console.log(products);
})

 function AddProductToScreen(p){
     productname.innerHTML = p.name
     productDescription.innerHTML = p.description

}

/*add random products to the bottom for cards*/
//get the elements for the cards by selecting all h2 and p elements in the other__card class

var h2productnames = document.querySelectorAll(".otherproducts__card h2")
var pproductdescription = document.querySelectorAll(".otherproducts__card p")

 function AddOtherProductToScreen(products) {

     console.log(h2productnames[0].innerHTML)

     for (var i = 0; i < 4; i++) {
         h2productnames[i].innerHTML = products[i].name
         pproductdescription[i].innerHTML = products[i].description
     };
     
};