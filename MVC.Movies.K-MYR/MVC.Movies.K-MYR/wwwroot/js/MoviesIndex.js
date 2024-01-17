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

    var table = $('#movies-table').DataTable({
        info: false,
        dom: '<"pb-1" t<"d-flex justify-content-between mt-3"<"pt-1"l>p>>',
        columns: [
            null, null, null, null, null, { orderable: false }, { orderable: false }
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

    $('#movies-search').on('keyup', function () {
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

    document.querySelectorAll('#movies-table tbody tr').forEach(function (row) {
        row.addEventListener('click', function (event) {
            const id = row.dataset.movieId;
            if (!event.target.matches('img.deleteIcon, img.updateIcon')) {
                window.location.href = '/Movies/Details/' + id;
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