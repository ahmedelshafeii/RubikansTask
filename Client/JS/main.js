$(document).ready(function () {

    var url = 'https://localhost:7210/api/'

    var customers;

    // Customers
    $.ajax({
        type: "GET",
        url: url + "Customers/customers",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            customers = response;
            $("#customersList").empty();
            for (var i = 0; i < response.length; i++) {
                $("#customersList").append("<option class='Option' value='" +
                    response[i].customerEnName + ' - ' + response[i].customerArName + "'></option>");
            }
        },
        failure: function () {
            console.log("Failure while calling customers");
        },
        error: function () {
            console.log("Error while calling customers");
        }
    });

    // Stores
    $.ajax({
        type: "GET",
        url: url + "Store/GetStores",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            $("#storeList").empty();
            for (var i = 0; i < response.length; i++) {
                $("#storeList").append("<option class='Option' value='" +
                    response[i].storeEnName + ' - ' + response[i].storeArName + "'></option>");
            }
        },
        failure: function () {
            console.log("Failure while calling stores");
        },
        error: function () {
            console.log("Error while calling stores");
        }
    });

    // Items
    $.ajax({
        type: "GET",
        url: url + "Item/Items",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (response) {
            console.log(response);




            for (var i = 0; i < response.length; i++) {
                $("#tableBody").append(
                    '<tr>' +
                    '   <td scope="row">' + (i + 1) + '</td>' +
                    // '<td>' +  response[i].name+'</td>' + 
                    '<td> <input placeholder=' + response[i].name + ' class="form-control" type="text" list="tdList' + i + '" name="tdName" id="tdName' + i + '" > <datalist id="tdList' + i + '" ></datalist> </td>' +
                    '<td>' + response[i].qty + '</td>' +
                    '<td>' + response[i].price + '</td>' +
                    '<td>' + response[i].cashDesc + '</td>' +
                    '<td>' + response[i].value + '</td>' +
                    '<td>' + response[i].vat + '</td>' +
                    '<td>' + response[i].taxValue + '</td>' +
                    '<td>' + response[i].totalInvoice + '</td>' +
                    '<td>' + response[i].notes + '</td>' +
                    '<td><i style="cursor: pointer;" class="material-icons" style="font-size:30px;">delete</i></td>' +
                    '</tr>'
                );


            }
            for (var i = 0; i < response.length; i++) {
                $("#tdList" + i).empty();
                for (var k = 0; k < response.length; k++) {
                    $("#tdList" + i).append("<option class='Option' value='" +
                    response[k].name + "'></option>");
                }
            }



        },
        failure: function () {
            console.log("Failure while calling Items");
        },
        error: function () {
            console.log("Error while calling Items");
        }
    });




})