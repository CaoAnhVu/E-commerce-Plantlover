var dataTable;

$(document).ready(function () {
    var url = window.location.search;
    if (url.includes("inprocess")) {
        loadDataTable("GetOrderList?status=inprocess");
    }
    else {
        if (url.includes("pending")) {
            loadDataTable("GetOrderList?status=pending");
        }
        else {
            if (url.includes("completed")) {
                loadDataTable("GetOrderList?status=completed");
            }
            else {
                if (url.includes("rejected")) {
                    loadDataTable("GetOrderList?status=rejected");
                }
                else {
                    loadDataTable("GetOrderList?status=all");
                }
            }
        }
    }
});

function loadDataTable(url) {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Order/" + url,
        },
        "columns": [
            { "data": "id", "width": "10%" },
            { "data": "name", "width": "15%" },
            { "data": "phoneNumber", "width": "15%" },
            { "data": "applicationUser.email", "width": "15%" },
            { "data": "orderStatus", "width": "15%" },
           /* { "data": "orderTotal", "width": "15%", render: $.fn.dataTable.render.number(',', ' đ', ',', 0) },*/
            {
                "data": "id",
                "render": function (data) {
                    console.log(data);
                    return `
                            <div class="text-center">
                                <a href="/Admin/Order/Details/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    <i class="fas fa-edit"></i> 
                                </a>
                            </div>
                           `;
                }, "width": "5%"
            }
        ],
        dom: 'Plfrtip',
        language: {
            "emptyTable": "Không có dữ liệu",
            "search": "Tìm kiếm:",
            "paginate": {
                "first": "Trang đầu",
                "last": "Trang cuối",
                "next": "Trang sau",
                "previous": "Trang trước"
            },
            "info": "Hiển thị _START_ đến _END_ sản phẩm / Tổng _TOTAL_ sản phẩm",
            "infoEmpty": "",
            "lengthMenu": "Hiện _MENU_ sản phẩm",
        },
    });
}