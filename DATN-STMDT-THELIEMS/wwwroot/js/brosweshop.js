function searchByShopName() {
    applyFilters();
}

function filterAccounts() {
    applyFilters();
}

function applyFilters() {
    const searchQuery = document.getElementById('searchInput').value;
    const statusFilter = document.getElementById('filterStatus').value;
    window.location.href = `/Admin/Shop/BrowseShop?searchQuery=${searchQuery}&statusFilter=${statusFilter}`;
}

function loadShopDetails(id) {
    $.get(`/Admin/Account/ShopDetails/${id}`, function (data) {
        $('#shopModalContent').html(data);
        $('#shopModal').modal('show');
    });
}