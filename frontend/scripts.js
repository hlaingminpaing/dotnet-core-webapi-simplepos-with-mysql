// Define the API endpoint for your backend
var API_ENDPOINT = "http://localhost:8080/api/products"; 

// AJAX POST request to save product data
document.getElementById("savestudent").onclick = function() {
    var inputData = {
        "id": $('#productId').val(),  // Assuming 'id' is sent to the API
        "name": $('#name').val(),
        "quantity": $('#quantity').val(),
        "price": $('#price').val()
    };

    $.ajax({
        url: API_ENDPOINT,
        type: 'POST',
        data: JSON.stringify(inputData),
        contentType: 'application/json; charset=utf-8',
        success: function(response) {
            document.getElementById("studentSaved").innerHTML = "Data Saved!";
            $('#productId').val('');
            $('#name').val('');
            $('#quantity').val('');
            $('#price').val('');
        },
        error: function() {
            alert("Error saving data.");
        }
    });
}

// AJAX GET request to retrieve all products
document.getElementById("getstudents").onclick = function() {
    $.ajax({
        url: API_ENDPOINT,
        type: 'GET',
        contentType: 'application/json; charset=utf-8',
        success: function(response) {
            // Clear any previous data in the table
            $('#studentTable tr').slice(1).remove();  

            // Loop through the response data and append each product to the table
            jQuery.each(response, function(i, data) {
                // Append product details to the table
                $("#studentTable").append("<tr> \
                    <td>" + data['id'] + "</td> \
                    <td>" + data['name'] + "</td> \
                    <td>" + data['quantity'] + "</td> \
                    <td>" + data['price'] + "</td> \
                    </tr>");
            });
        },
        error: function() {
            alert("Error retrieving data.");
        }
    });
}
