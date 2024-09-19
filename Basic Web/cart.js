outputItem();

function getItemList() {
    if (localStorage.getItem("itemlist") == null) {
        localStorage.getItem("itemlist", "[]");
    }
    let itemlist = localStorage.getItem("itemlist");
    return itemlist;
}

function outputItem() {
    let items = JSON.parse(getItemList());
    let output = "";
    items.forEach((item) => {
        output +=  `<div class="col-md-4" height = "200px">
        <div class="product mb-4">
            <div class = "productImg" style="background-image: url(${Object.values(values.products[i].images)[0]});"> 
            </div>
          <div class="product-details">
            <h3 class="product-title">${values.products[i].title}</h3>
            <p class="product-price">$${values.products[i].price}</p>
          </div>
        </div>
      </div>`;
    });
    document.querySelector(".product-output").innerHTML = output;
}