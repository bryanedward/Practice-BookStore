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
            {"data": "nameBook","width": "30%"},
            {"data": "author", "width": "30%"},
            {"data": "isbn", "width": "30%"},
            {
                "data" : "id",
                "render": function (data) {
                    return ` <div class="text-center">
                                <a href="bookList/Edit?id=${data}" 
                                    class="btn btn-success" 
                                    style="cursor: pointer">
                                    Editar
                                </a> &nbsp;
                                <a href="#" 
                                    class="btn btn-danger"
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
    
    console.log(dataTable)
}
