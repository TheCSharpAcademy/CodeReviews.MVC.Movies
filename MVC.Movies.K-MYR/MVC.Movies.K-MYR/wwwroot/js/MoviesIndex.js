document.addEventListener('DOMContentLoaded', function () {    
    var table = $('#movies-table').DataTable({
        info: false,
        dom: 't<"d-flex justify-content-between mt-3"<"pt-2"l>p>',
        columns: [
            null, null, null, null, null, { orderable: false }
        ]
    });

    $('#movies-search').on('keyup', function() {
        table.search(this.value).draw();
    })       
});
