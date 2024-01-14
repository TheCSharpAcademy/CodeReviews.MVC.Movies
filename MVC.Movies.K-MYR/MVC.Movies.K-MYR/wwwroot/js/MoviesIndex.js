document.addEventListener('DOMContentLoaded', function () {    
    var table = $('#movies-table').DataTable({
        info: false,
        dom: '<"pb-1" t<"d-flex justify-content-between mt-3"<"pt-1"l>p>>',
        columns: [
            null, null, null, null, null, { orderable: false }, { orderable: false }
        ],
        scrollX: true,
        scrollCollapse: true     
    });

    $('#movies-search').on('keyup', function() {
        table.search(this.value).draw();
    })

    document.querySelectorAll('#movies-table tbody tr').forEach(function(row) {
        row.addEventListener('click', function(event) {
            const id = row.dataset.movieId;         
            if(!event.target.matches('img.deleteIcon, img.updateIcon')) {
                window.location.href = '/Movies/Details/' + id;
            }
        })
    })   
});

function openUpdateMovieModal(id, title, releaseDate, genre, price, rating) {
    $("#updateMovie-label").text(`Edit "${title}"`);
    $("#updateMovie-input_id").val(id);
    $("#updateMovie-input_title").val(title);
    $("#updateMovie-input_release").val(releaseDate);
    $("#updateMovie-input_genre").val(genre);
    $("#updateMovie-input_price").val(price);
    $("#updateMovie-input_rating").val(rating);    
    $("#updateMovie").modal('show');
}

function openDeleteMovieModal(id, title) {
    $('#deleteMovie-label').text(`Delete "${title}"`);
    $('#deleteConfirmationMessage').text(`Are you sure you want to delete "${title}" ?`);
    $('#deleteMovie-input_id').val(id);
    $('#deleteMovie').modal('show');
}