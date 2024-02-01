document.addEventListener('DOMContentLoaded', function () {
    setTimeout(function () {
        $("#successMessage").alert("close");
        $("#errorMessage").alert("close")
    }, 3000);
});

function openUpdateTVShowModal(id, title, seasons, releaseDate, genre, price, rating) {    
    $("#updateTVShow-label").text(`Edit "${title}"`);
    $("#updateTVShow-input_id").val(id);
    $("#updateTVShow-input_title").val(title);
    $("#updateTVShow-input_seasons").val(seasons);
    $("#updateTVShow-input_release").val(releaseDate);
    $("#updateTVShow-input_genre").val(genre);
    $("#updateTVShow-input_price").val(price);
    $("#updateTVShow-input_rating").val(rating);
    $("#updateTVShow").modal('show');
};

function openDeleteTVShowModal(id, title) {
    $('#deleteTVShow-label').text(`Delete "${title}"`);
    $('#deleteConfirmationMessage').text(`Are you sure you want to delete "${title}" ?`);
    $('#deleteTVShow-input_id').val(id);
    $('#deleteTVShow').modal('show');
};
