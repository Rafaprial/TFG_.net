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
                        <a onClick=Delete('/Admin/Pelicula/Delete/${data}') class="ms-2 btn btn-danger"><i class="bi bi-trash-fill"></i>&nbsp; Delete</a>
                        
                    </div>
                    `
                },
                "width": "15%"
            },

            

        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: 'Estas seguro de borrar la pelicula?',
        text: "No podras deshacer cambios!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si, borrar!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
        }
    })
}