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

function filterAccounts() {
    var status = document.getElementById("filterStatus").value;
    console.log("Filtering shops with status:", status); // Xem giá trị status
    fetch(`/Admin/Account/FilterShops?status=${status}`)
        .then(response => {
            if (!response.ok) {
                throw new Error('Network response was not ok');
            }
            return response.json();
        })
        .then(data => {
            console.log("Data received:", data); // Kiểm tra dữ liệu nhận được
            updateTable(data);
        })
        .catch(error => {
            console.error('Error:', error);
        });
}

function updateTable(data) {
    // Tìm phần tử <tbody> trong bảng
    var tableBody = document.querySelector("table tbody");
    tableBody.innerHTML = ""; // Xóa tất cả các hàng hiện có trong <tbody>

    // Duyệt qua dữ liệu và tạo các hàng mới
    data.forEach((shop, index) => {
        var row = document.createElement("tr");

        // Tạo và thêm các ô (cột) vào hàng
        var selectCell = document.createElement("td");
        if (shop.Status !== "Đã duyệt") {
            var checkbox = document.createElement("input");
            checkbox.type = "checkbox";
            checkbox.name = "selectedShops";
            checkbox.value = shop.Id;
            selectCell.appendChild(checkbox);
        }
        row.appendChild(selectCell);

        var sttCell = document.createElement("td");
        sttCell.textContent = index + 1;
        row.appendChild(sttCell);

        var idCell = document.createElement("td");
        idCell.textContent = shop.Id;
        row.appendChild(idCell);

        var nameCell = document.createElement("td");
        nameCell.textContent = shop.Name;
        row.appendChild(nameCell);

        var phoneCell = document.createElement("td");
        phoneCell.textContent = shop.Phone;
        row.appendChild(phoneCell);

        var emailCell = document.createElement("td");
        emailCell.textContent = shop.Email;
        row.appendChild(emailCell);

        var statusCell = document.createElement("td");
        statusCell.textContent = shop.Status;
        statusCell.className = shop.Status === "Đã duyệt" ? "text-success" : "text-danger";
        row.appendChild(statusCell);

        var actionCell = document.createElement("td");
        var detailLink = document.createElement("a");
        detailLink.href = "#";
        detailLink.textContent = "Chi tiết";
        detailLink.className = "text-primary fw-bold";
        actionCell.appendChild(detailLink);
        row.appendChild(actionCell);

        // Thêm hàng vào <tbody> của bảng
        tableBody.appendChild(row);
    });
}




function searchByShopName() {
    var shopName = document.getElementById("searchInput").value;

    // Kiểm tra nếu tên trống thì không làm gì
    if (!shopName.trim()) {
        return;
    }

    fetch(`/Admin/Account/SearchShopsByName?shopName=${encodeURIComponent(shopName)}`)
        .then(response => response.json())
        .then(data => {
            updateTable(data);
        })
        .catch(error => {
            console.error('Error:', error);
        });
}
