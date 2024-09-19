console.log("welcome to ITEC final store");
/* Here are the endpoints you need to hit */
/* https://dummyjson.com/products/  for all products*/
/* https://dummyjson.com/products/category/smartphones an example of a filter category (choose 4-5) */

/* call your start up functions here */
displayProductsDefault();
async function getProducts(){
    const response = await fetch(`https://dummyjson.com/products?limit=6`)
    .then((res)=>res.json())
    .then((data)=>data);
    return response;
}
async function getCategories(value){
    const response = await fetch(`https://dummyjson.com/products/category/${value}?limit=5`)
    .then((res)=>res.json())
    .then((data)=>data)
    return response;
}

/* declare your global vars here */
let phone = document.querySelector(".smartphone");
let laptop = document.querySelector(".laptop");
let skincare = document.querySelector(".skincare");
let furniture = document.querySelector(".furniture");
let AddBtn = document.querySelector(".btn-secondary");
let cartTotal = document.querySelector(".cart-total")

/* add your event listeners here */
phone.addEventListener("click",(e)=>{
    e.preventDefault();
    displayProducts("smartphones");
})
laptop.addEventListener("click",(e)=>{
    e.preventDefault();
    displayProducts("laptops")
})
skincare.addEventListener("click",(e)=>{
    e.preventDefault();
    displayProducts("skincare")
})
furniture.addEventListener("click",(e)=>{
    e.preventDefault();
    displayProducts("home-decoration")
})

AddBtn.addEventListener("click", () => {
    addItem();
})

/* create script functions here (remember to use async + await where needed) */
function addItem() {
    let itemlist = getItemList();
    console.log(itemlist);
    let currentUser = localStorage.getItem("currentUser");
    itemlist = JSON.parse(itemlist);
    currentUser = JSON.parse(currentUser);
    itemlist.push(currentUser);
    storeFriendList(itemlist);
}

function getItemList() {
    if (localStorage.getItem("itemlist") == null) {
        localStorage.getItem("itemlist", "[]");
    }
    let itemlist = localStorage.getItem("itemlist");
    return itemlist;
}

function storeItemList(itemlist) {
    localStorage.setItem("itemlist", JSON.stringify(itemlist));
}

async function displayProducts(value){
    let values = await getCategories(value);
    console.log(values);
    console.log(values.products.length);
    console.log(Object.values(values.products[0]));
    let output = "";

    for(let i=0;i<values.products.length;i++){
        output +=  `<div class="col-md-4" height = "200px">
        <div class="product mb-4">
            <div class = "productImg" style="background-image: url(${Object.values(values.products[i].images)[0]});"> 
            </div>
          <div class="product-details">
            <h3 class="product-title">${values.products[i].title}</h3>
            <p class="product-price">$${values.products[i].price}</p>
            <div class="product-buttons">
              <button type="button" class="btn btn-primary">Buy Now</button>
              <button type="button" class="btn btn-secondary" id ="BtnPur">Add to Cart</button>
            </div>
          </div>
        </div>
      </div>`;
    }
    document.querySelector(".product-output").innerHTML = output;
    pay();
}


async function displayProductsDefault(){
    const response = await getProducts();
    console.log(response);
    let output = "";

    for(let i=0;i<response.products.length;i++){
        output += `
        <div class="col-md-4" height = "200px">
        <div class="product mb-4">
            <div class = "productImg" style="background-image: url(${Object.values(response.products[i].images)[0]});"> 
            </div>
          <div class="product-details">
            <h3 class="product-title">${response.products[i].title}</h3>
            <p class="product-price">$${response.products[i].price}</p>
            <div class="product-buttons">
              <button type="button" class="btn btn-primary">Buy Now</button>
              <button type="button" class="btn btn-secondary" id ="BtnPur">Add to Cart</button>
            </div>
          </div>
        </div>
      </div>`;
        
    }
    document.querySelector(".product-output").innerHTML = output;
    pay();
}

let total = 0;
function pay() {
    let purchaseBtns = document.querySelectorAll("button[id^=BtnPur]");

    purchaseBtns.forEach((btn) => {
        btn.addEventListener("click", (event) => {
            total += 1;
            cartTotal.textContent = total;
        });
    });
}