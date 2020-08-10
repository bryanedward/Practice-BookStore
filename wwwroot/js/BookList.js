$(document).ready(function(){
    LoadDataTable()
})

var dataTable;

function LoadDataTable() {
    dataTable = $('#myTable').DataTable({
        "ajax":{
            "url":"/api/book",
            "type":"GET",
            "datatype":"json"
        },
        "columns":[
            {"data": "nameBook","width": "20%"},
            {"data": "author", "width": "20%"},
            {"data": "isbn", "width": "20%"},
            {
                "data" : "id",
                "render": function (data) {
                    return ` <div class="text-center">
                                <a href="Edit?id=${data}" 
                                    class="btn btn-success" 
                                    style="cursor: pointer">
                                    Editar
                                </a> &nbsp;
                                <a href="#" 
                                    class="btn btn-danger"
                                    onclick="Delete('api/book?id='+${data})"
                                    style="cursor: pointer">
                                    Eliminar
                                </a>
                            </div>
                    `;
                },"width": "30%"
            }
        ],
        "language":{
            "emptyTable":"no hay datos"
        },
        "width":"100%"
    });
}
function Delete(url) {
    Swal.fire({
        title: "estas seguro",
        text: "una vez eliminado los datos ya no se podran eliminar",
        icon: "warning",
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete){
           $.ajax({
               type: "DELETE",
               url: url,
               success: function (data) {
                   if(data.success){
                       toastr.success(data.message)
                        dataTable.ajax.reload()
                   }else {
                       toastr.error(data.message)
                   }
               }
           })
        }
    })
}