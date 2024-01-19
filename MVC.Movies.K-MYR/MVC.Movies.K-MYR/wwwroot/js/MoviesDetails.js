function openUpdateMovieModal(id, title, releaseDate, genre, price, rating) {
    $("#updateMovie-label").text(`Edit "${title}"`);
    $("#updateMovie-input_id").val(id);
    $("#updateMovie-input_title").val(title);
    $("#updateMovie-input_release").val(releaseDate);
    $("#updateMovie-input_genre").val(genre);
    $("#updateMovie-input_price").val(price);
    $("#updateMovie-input_rating").val(rating);
    $("#updateMovie").modal('show');
};

function openDeleteMovieModal(id, title) {
    $('#deleteMovie-label').text(`Delete "${title}"`);
    $('#deleteConfirmationMessage').text(`Are you sure you want to delete "${title}" ?`);
    $('#deleteMovie-input_id').val(id);
    $('#deleteMovie').modal('show');
};