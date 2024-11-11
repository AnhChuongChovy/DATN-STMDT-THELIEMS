function loadUserDetails(id) {
    $.get('/Admin/Account/UserDetails/' + id, function (data) {
        // Cập nhật nội dung của modal với dữ liệu trả về từ PartialView
        $('#userModalContent').html(data);
        $('#userModal').modal('show'); // Hiển thị modal
    });
}
function showLockAccountModal(userId) {
    // Đặt URL của nút xác nhận với userId cụ thể
    const confirmBtn = document.getElementById('confirmLockBtn');
    confirmBtn.href = `/Admin/Account/LockAccount/${userId}`;

    // Hiển thị modal
    $('#lockAccountModal').modal('show');
}

function showUnLockAccountModal(userId) {
    // Đặt URL của nút xác nhận với userId cụ thể
    const confirmBtn = document.getElementById('confirmUnLockBtn');
    confirmBtn.href = `/Admin/Account/UnLockAccount/${userId}`;

    // Hiển thị modal
    $('#unlockAccountModal').modal('show');
}

