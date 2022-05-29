var dataTable;

$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#myTable').dataTable({
        "ajax": {
            "url": "/Admin/Pelicula/GetAll"
        },
        "columns": [
            { "data": "title", "width": "15%" },
            { "data": "description", "width": "15%" },
            { "data": "duration", "width": "15%" },
            { "data": "director", "width": "15%" },
            { "data": "categoria.name", "width": "15%" },
            { "data": "pegi.name", "width": "15%" },
            { "data": "price", "width": "15%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                    <div class="w-75 btn-group" role="group">
                        <a href="/Admin/Pelicula/Upsert?id=${data}" class="btn btn-secondary"><i class="bi bi-pencil-square"></i>&nbsp; Edit</a>
                        <a href="/Admin/Pelicula/Delete?id=${data}" class="ms-2 btn btn-danger"><i class="bi bi-trash-fill"></i>&nbsp; Delete</a>
                        
                    </div>
                    `
                },
                "width": "15%"
            },

            

        ]
    });
}