const $yearRange = $("#yearRange");
const $inputYearFrom = $("#yearFrom");
const $inputYearTo = $("#yearTo");
const yearMin = $inputYearFrom.data('min');
const yearMax = $inputYearTo.data('max');
var yearFrom;
var yearTo;

const $priceRange = $("#priceRange");
const $inputPriceFrom = $("#priceFrom");
const $inputPriceTo = $("#priceTo");
const priceMin = $inputPriceFrom.data('min');
const priceMax = $inputPriceTo.data('max');
var priceFrom = priceMin;
var priceTo = priceMax;

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

    $inputYearFrom.on("input", function () {
        var val = this.value;

        if (val < yearMin) {
            val = yearMin;
        } else if (val > yearTo) {
            val = yearTo;
        }

        $yearRange.data("ionRangeSlider").update({
            from: val
        });

        yearFrom = val;
    });

    $inputYearTo.on("input", function () {
        var val = this.value;

        if (val < yearFrom) {
            val = yearFrom;
        } else if (val > yearMax) {
            val = yearMax;
        }

        $yearRange.data("ionRangeSlider").update({
            to: val
        });

        yearTo = val;
    });

    $inputPriceFrom.on("input", function () {
        var val = this.value;

        if (val < priceMin) {
            val = priceMin;
        } else if (val > priceTo) {
            val = priceTo;
        }

        $priceRange.data("ionRangeSlider").update({
            from: val
        });
    });

    $inputPriceTo.on("input", function () {
        var val = this.value;

        if (val < priceFrom) {
            val = priceFrom;
        } else if (val > priceMax) {
            val = priceMax;
        }

        priceRange.data("ionRangeSlider").update({
            to: val
        });
    });

    document.querySelectorAll('#tvshows-table tbody tr').forEach(function (row) {
        row.addEventListener('click', function (event) {
            const id = row.dataset.tvshowId;
            if (!event.target.matches('img.deleteIcon, img.updateIcon')) {
                window.location.href = '/TVShows/Details/' + id;
            }
        });
    });
});

function updateYearInputs(data) {
    $inputYearFrom.val(data.from);
    $inputYearTo.val(data.to);
    yearFrom = data.from;
    yearTo = data.to;
};

function updatePriceInputs(data) {
    $inputPriceFrom.val(data.from);
    $inputPriceTo.val(data.to);
};

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