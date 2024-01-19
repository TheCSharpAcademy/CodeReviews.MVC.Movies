document.addEventListener('DOMContentLoaded', function () {
    setTimeout(function () {
        $("#successMessage").alert("close");
        $("#errorMessage").alert("close")
    }, 3000);

    var table = $('#tvshows-table').DataTable({
        info: false,
        dom: '<"pb-1" t<"d-flex justify-content-between mt-3"<"pt-1"l>p>>',
        columns: [
            null, null, null, null, null, null, { orderable: false }, { orderable: false }
        ],
        scrollX: true,
        scrollCollapse: true
    });

    $yearRange.ionRangeSlider({
        type: "integer",
        min: yearMin,
        max: yearMax,
        skin: "square",
        min_interval: 0,
        prettify_enabled: false,
        hide_min_max: true,
        onStart: updateYearInputs,
        onChange: updateYearInputs
    });

    $priceRange.ionRangeSlider({
        type: "double",
        min: priceMin,
        max: priceMax,
        step: 0.01,
        skin: "square",
        min_interval: 0,
        prettify_enabled: false,
        hide_min_max: true,
        onStart: updatePriceInputs,
        onChange: updatePriceInputs
    });

    $('#tvshows-search').on('keyup', function () {
        table.search(this.value).draw();
    });
});

function openUpdateTVShowModal(id, title, releaseDate, genre, price, rating) {
    $("#updateTVShow-label").text(`Edit "${title}"`);
    $("#updateTVShow-input_id").val(id);
    $("#updateTVShow-input_title").val(title);
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