window.onload = function () {




    /*For 'add to cart' button in the gallery page

    let addCart = document.getElementById("@productId");
    if (!addClick)
    {
        return;
    }
    addCart.onClick function()
    {
        
    }

    need to use AJAX to update the cart number on the top right of screen page (any idea how?)*/


    let elem = document.getElementById("abc");
    elem.onmouseover = function () {
        elem.style.border = "2px solid #29b6f6";
        elem.style.backgroundColor = "#e1f5fe";
    }
    elem.onmouseout = function () {
        elem.style.border = "";
        elem.style.backgroundColor = "";
    }
}



