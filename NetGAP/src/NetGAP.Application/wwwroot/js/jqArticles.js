var save_method; //for save method string
var table;

$(document).ready(function () {
    //$.support.cors = true;
    reload_store();
});

function selectStore()
{
    if($(this).data('status')=='edit')
    {
        reload_table($(this).data('id'));
    }
    else if ($(this).data('status') == 'add')
    {
        add_store();
    }
    return false;
}



function add_article()
{
    save_method = 'add';
    $('#form_article')[0].reset(); // reset form on modals
    $('.form-group').removeClass('has-error'); // clear error class
    $('.help-block').empty(); // clear error string
    $('#article_modal_form').modal('show'); // show bootstrap modal
    $('#btnSaveArticle').attr('disabled', false); //set button enable
    $('.modal-title').text('Add Person'); // Set Title to Bootstrap modal title
    $('[name="StoreId"]').val($('[name="DataId"]').val());
}

function edit_article(id)
{
    save_method = 'update';
    $('#form_article')[0].reset(); // reset form on modals
    $('.form-group').removeClass('has-error'); // clear error class
    $('.help-block').empty(); // clear error string

    //Ajax Load data from ajax
    $.ajax({
        url: "http://localhost:4063/services/Articles/" + id,
        type: "GET",
        dataType: "JSON",
        headers: {
            "Authorization": "Basic " + btoa("my_user:my_password")
        },
        success: function(data)
        {

            if (data.success == true)
            {
                $('[name="StoreId"]').val($('[name="DataId"]').val());
                $('[name="Id"]').val(data.article.id);
                $('[name="Name"]').val(data.article.name);
                $('[name="Description"]').val(data.article.description);
                $('[name="Price"]').val(data.article.price);
                $('[name="TotalInShelf"]').val(data.article.totalInShelf);
                $('[name="TotalInVault"]').val(data.article.totalInVault);
                $('[name="Store"]').val(data.article.store);
                $('#article_modal_form').modal('show'); // show bootstrap modal when complete loaded
                $('#btnSaveArticle').attr('disabled', false); //set button enable
                $('.modal-title').text('Edit Article'); // Set title to Bootstrap modal title
            }
        },
        error: function (jqXHR, textStatus, errorThrown)
        {
            alert('Error get data from ajax');
        }
    });
}

function delete_article(id) {
    if (confirm('Are you sure delete this data?')) {
        // ajax delete data to database
        $.ajax({
            url: "http://localhost:4063/services/Articles/" + id,
            type: "DELETE",
            dataType: "JSON",
            headers: {
                "Authorization": "Basic " + btoa("my_user:my_password")
            },
            success: function (data) {
                //if success reload ajax table
                $('#modal_form').modal('hide');
                reload_table($('[name="DataId"]').val());
            },
            error: function (jqXHR, textStatus, errorThrown) {
                alert('Error deleting data');
            }
        });

    }
}

function reload_table(StoreId)
{

    $('[name="DataId"]').val(StoreId);
    
    $.ajax({
        url: "http://localhost:4063/services/Articles/Stores/"+StoreId,
        type: "GET",
        dataType: "json",
        headers: {
            "Authorization": "Basic " + btoa("my_user:my_password")
        },
        success: function (data) {
            $('#tblResults tbody>tr').remove();
            if (data.success == true) {
                var items = data.articles;
                var i = 0, len = items.length;
                while (i < len) {
                    var renglon = $('<tr></tr>')
                        .append($('<td></td>').text(items[i].name))
                        .append($('<td></td>').text(items[i].price))
                        .append($('<td></td>').text(items[i].totalInShelf))
                        .append($('<td></td>').text(items[i].totalInVault))
                        .append($('<td></td>').html('<a class="btn btn-sm btn-primary" href="javascript:void(0)" title="Edit" onclick="edit_article(' + "'" + (items[i].id) + "'" + ')"><i class="glyphicon glyphicon-pencil"></i> Edit</a><a class="btn btn-sm btn-danger" href="javascript:void(0)" title="Delete" onclick="delete_article(' + "'" + (items[i].id) + "'" + ')"><i class="glyphicon glyphicon-trash"></i> Del</a>'));
                        //.append($('<td></td>').append($('<a></a>').attr('href', 'javascript:void(0)').attr({ 'class': 'btn btn-sm btn-primary' }).attr('onclick', 'edit_article(' + items[i].id + ')')));

                    if ($("#tblResults tbody>tr").length > 0) {
                        renglon.insertAfter("#tblResults tbody>tr:last");
                    } else {
                        renglon.appendTo("#tblResults tbody");
                    }
                    i = i + 1;
                }
            }


        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert('Error get data from ajax');
        }
    });
}

function save_article()
{
    $('#btnSaveArticle').text('saving...'); //change button text
    $('#btnSaveArticle').attr('disabled', true); //set button disable
    var url = "http://localhost:4063/services/Articles/";
    var typeMetod = '';
    if(save_method == 'add') {
        typeMetod = 'post';
    } else {
        typeMetod = 'put';
        url = url + '/' + $('[name="Id"]').val();
    }

    // ajax adding data to database
    
    $.ajax({
        url : url,
        type: typeMetod,
        data: $('#form_article').serialize(),
        dataType: "JSON",
        headers: {
            "Authorization": "Basic " + btoa("my_user:my_password")
        },
        success: function (data)
        {

            if (data.success) //if success close modal and reload ajax table
            {
                $('#article_modal_form').modal('hide');
                reload_table($('[name="DataId"]').val());
            }
            else
            {
                alert('Erro adding /update data: ' + data.error_message);
            }

            $('#btnSaveArticle').text('save'); //change button text
            $('#btnSaveArticle').attr('disabled',false); //set button enable


        },
        error: function (jqXHR, textStatus, errorThrown)
        {
            alert('Error adding / update data');
            $('#btnSaveArticle').text('save'); //change button text
            $('#btnSaveArticle').attr('disabled', false); //set button enable

        }
    });
}

/*Store*/
function add_store() {
    save_method = 'add';
    $('#form_store')[0].reset(); // reset form on modals
    $('.form-group').removeClass('has-error'); // clear error class
    $('.help-block').empty(); // clear error string
    $('#store_modal_form').modal('show'); // show bootstrap modal
    $('#btnSaveStore').attr('disabled', false); //set button enable
    $('.modal-title').text('Add Store'); // Set Title to Bootstrap modal title
}

function save_store() {
    $('#btnSaveStore').text('saving...'); //change button text
    $('#btnSaveStore').attr('disabled', true); //set button disable
    var url;

    if (save_method == 'add') {
        url = "http://localhost:4063/services/Stores/";
    } else {
        url = "http://localhost:4063/services/Stores/";
    }

    // ajax adding data to database
    $.ajax({
        url: url,
        type: "POST",
        data: $('#form_store').serialize(),
        dataType: "json",
        headers: {
            "Authorization": "Basic " + btoa("my_user:my_password")
        },
        success: function (data) {

            if (data.success) //if success close modal and reload ajax table
            {
                $('#store_modal_form').modal('hide');
                reload_store();
            }
            else
            {
                alert('Erro adding /update data: ' + data.error_message);
            }

            $('#btnSaveStore').text('save'); //change button text
            $('#btnSaveStore').attr('disabled', false); //set button enable


        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert('Error adding / update data');
            $('#btnSaveStore').text('save'); //change button text
            $('#btnSaveStore').attr('disabled', false); //set button enable

        }
    });
}

function reload_store()
{
    $.ajax({
        url: "http://localhost:4063/services/Stores/",
        type: "GET",
        dataType: "json",
        headers: {
            "Authorization": "Basic " + btoa("my_user:my_password")
        },
        success: function (data) {
            $('#Stores').html('');
            var results = '';
            if (data.success == true) {
                var items = data.stores;
                var i = 0, len = items.length;
                while (i < len) {
                    results += '<a href="#" class="list-group-item" data-id="' + items[i].id + '" data-status="edit">' + items[i].name + '</a>'
                    i = i + 1;
                }
            }
            results += '<a href="#" class="list-group-item" data-status="add">Add Store</a>'
            $('#Stores').html(results);
            $('#Stores').children().on("click", selectStore)

        },
        error: function (jqXHR, textStatus, errorThrown) {
            alert('Error get data from ajax');
        }
    });
}

