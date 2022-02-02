//Loading Data in Table when documents is ready  
$(document).ready(function () {
    loadData();
});

//Load Data function  
function loadData() {
    $.ajax({
        url: "/Librarians/List",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.LibrarianID + '</td>';
                html += '<td>' + item.Name + '</td>';
                html += '<td>' + item.Age + '</td>';
                html += '<td>' + item.Email + '</td>';
                html += '<td>' + item.Address + '</td>';
                html += '<td><a href="#" onclick="return getbyID(' + item.LibrarianID + ')">Edit</a> | <a href="#" onclick="Delele(' + item.LibrarianID + ')">Delete</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Add Data Function   
function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var lbnObj = {
        LibrarianID: $('#LibrarianID').val(),
        Name: $('#Name').val(),
        Age: $('#Age').val(),
        Email: $('#Email').val(),
        Address: $('#Address').val()
    };
    $.ajax({
        url: "/Librarians/Add",
        data: JSON.stringify(lbnObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//Function for getting the Data Based upon Librarian ID
function getbyID(lbnID) {
    $('#Name').css('border-color', 'lightgrey');
    $('#Age').css('border-color', 'lightgrey');
    $('#Email').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
    $.ajax({
        url: "/Librarians/getbyID/" + lbnID,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#LibrarianID').val(result.LibrarianID);
            $('#Name').val(result.Name);
            $('#Age').val(result.Age);
            $('#Email').val(result.Email);
            $('#Address').val(result.Address);

            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

//function for updating Librarian's record
function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var lbnObj = {
        LibrarianID: $('#LibrarianID').val(),
        Name: $('#Name').val(),
        Age: $('#Age').val(),
        Email: $('#Email').val(),
        Address: $('#Address').val(),
    };
    $.ajax({
        url: "/Librarians/Update",
        data: JSON.stringify(lbnObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#LibrarianID').val("");
            $('#Name').val("");
            $('#Age').val("");
            $('#Email').val("");
            $('#Address').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

//function for deleting Librarian's record
function Delele(ID) {
    var ans = confirm("Are you sure you want to delete this Record?");
    if (ans) {
        $.ajax({
            url: "/Librarians/Delete/" + ID,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

//Function for clearing the textboxes  
function clearTextBox() {
    $('#LibrarianID').val("");
    $('#Name').val("");
    $('#Age').val("");
    $('#Email').val("");
    $('#Address').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
    $('#Name').css('border-color', 'lightgrey');
    $('#Age').css('border-color', 'lightgrey');
    $('#Email').css('border-color', 'lightgrey');
    $('#Address').css('border-color', 'lightgrey');
}
//Valdidation using jquery  
function validate() {
    var isValid = true;
    if ($('#Name').val().trim() == "") {
        $('#Name').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Name').css('border-color', 'lightgrey');
    }
    if ($('#Age').val().trim() == "") {
        $('#Age').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Age').css('border-color', 'lightgrey');
    }
    if ($('#Email').val().trim() == "") {
        $('#Email').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Email').css('border-color', 'lightgrey');
    }
    if ($('#Address').val().trim() == "") {
        $('#Address').css('border-color', 'Red');
        isValid = false;
    }
    else {
        $('#Address').css('border-color', 'lightgrey');
    }
    return isValid;
}