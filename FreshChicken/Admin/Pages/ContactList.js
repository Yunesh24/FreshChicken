$(document).ready(function () {

    //alert("Category added Sucessfully");
    GetAddList();

});
var SaveContact = function () {
    var id = $("#hdnId").val();
    var name = $("#txtName").val();
    var e_mail = $("#txtE_mail").val();
    var phone = $("#txtPhone").val();
    var message = $("#txtMessage").val();
    var model = { Id: id, Name: name, E_mail: e_mail, Phone: phone, Message: message };

$.ajax({
        url: "/ContactList/SaveContactList",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (response) {
            alert("successfully");
            GetAddList();
        }
    })
};
var GetAddList = function () {
    $.ajax({
        url: "/ContactList/GetAddList",
        method: "Post",
        //data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        datatype: "json",
        async: false,
        success: function (response) {
            var html = "";
            $("#tbl_Contact tbody").empty();
            $.each(response.model, function (index, elementValue) {
                html += "<tr><td>" + elementValue.Id + "</td><td>" + elementValue.Name + "</td><td>" + elementValue.E_mail + "</td><td>" + elementValue.Phone + "</td><td>" + elementValue.Message + "</td><td><input type = 'submit' value = 'Edit' onClick = 'Editdata(" + elementValue.Id + ")' /></td><td><input type = 'submit' value = 'Delete' onClick = 'deleteRecord(" + elementValue.Id + ")' /></td></tr>";

            });
            $("#tbl_Contact tbody").append(html);
        }
    });
}
var Editdata = function (id) {
    var model = { Id: id };
    ///alert("Record Edit Successfully ....");
    $.ajax({

        url: "/ContactList/EditData ",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {

            $("#hdnId").val(response.model.Id);
            $("#txtName").val(response.model.Name);
            $("#txtE_mail").val(response.model.E_mail);
            $("#txtPhone").val(response.model.Phone);
            $("#txtMessage").val(response.model.Message);
        }
    });
}
var ClearData = function () {
    $("#hdnId").val("");
    $("#txtName").val("");
    $("#txtE_mail").val("");
    $("#txtPhone").val("");
    $("#txtMessage").val("");
}
var deleteRecord = function (id) {
    var model = { Id: id };
    $.ajax({
        url: "/ContactList/deleteRecord",
        method: "post",
        data: JSON.stringify(model),
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        async: false,
        success: function (response) {
            alert("Record Deleted Successfully ....");
            GetAddList();
        }
    });
}


