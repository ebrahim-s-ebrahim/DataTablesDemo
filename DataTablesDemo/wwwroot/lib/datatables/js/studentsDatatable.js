$(document).ready(function () {
    $('#Students').dataTable({
        "serverSide": true,
        "filter": true,
        "ajax": {
            "url": "/api/students",
            "type": "POST",
            "datatype": "json"
        },
        "columnDefs": [{
            "targets": [0],
            "visible": false,
            "searchable": false
        }],
        "columns": [
            {"data": "id", "name": "id", "autowidth": true},
            { "data": "firstName", "name": "FirstName", "autowidth": true},
            { "data": "lastName", "name": "LastName", "autowidth": true},
            { "data": "email", "name": "Email", "autowidth": true },
            {
                "render": function (data, type, row)
                {
                    return '<span>' + row.dateOfBirth.split('T')[0] + '</span>'
                },
                "name": "DateOfBirth"
            },
            {
                "render": function (data, type, row)
                {
                    return `<a href="#" class="btn btn-danger" onclick=DeleteCustomer("' + row.id + '"); > Delete </a>`
                },
                "orderable": false
            }            
        ]
    });
});

function DeleteCustomer() {
    alert('DELETED!')
}