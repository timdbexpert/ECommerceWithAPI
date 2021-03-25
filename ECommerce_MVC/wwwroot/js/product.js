function updateCartProduct() {
    var products = [];
    var productids;

    // if (products.length == 0) {
    productids = Cookies.get('ProductCart');
    if (productids != undefined && productids != "" && productids != null) {
        var ids = productids.split('-');

        if (ids.length == 1) {
            products.push(ids);
        };
        if (ids.length >1)
        {
            for (f of ids) {
                products.push(f);
            }
        }
        
        
    }
    $("#cartProductCount").html(products.length)    
}