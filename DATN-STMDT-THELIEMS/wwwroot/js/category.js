function showConfirmHideModal(categoryId) {
    const form = document.getElementById("hideCategoryForm");
    form.action = "/Admin/Category/HideCategory/" + categoryId;
    new bootstrap.Modal(document.getElementById("confirmHideModal")).show();
}

function showConfirmDisplayModal(categoryId) {
    const form = document.getElementById("displayCategoryForm");
    form.action = "/Admin/Category/DisplayCategory/" + categoryId;
    new bootstrap.Modal(document.getElementById("confirmDisplayModal")).show();
}

function previewImage(event) {
    const image = document.getElementById('imagePreview');
    image.src = URL.createObjectURL(event.target.files[0]);
    image.style.display = 'block';
}
