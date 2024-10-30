function updatePlaceholder() {
    var selectBox = document.getElementById("searchBy");
    var searchInput = document.getElementById("searchInput");

    switch (selectBox.value) {
        case "orderCode":
            searchInput.placeholder = "Nhập mã đơn hàng";
            break;
        case "productCode":
            searchInput.placeholder = "Nhập mã sản phẩm";
            break;
        case "productName":
            searchInput.placeholder = "Nhập tên sản phẩm";
            break;
        case "buyerName":
            searchInput.placeholder = "Nhập tên người mua";
            break;
    }
}