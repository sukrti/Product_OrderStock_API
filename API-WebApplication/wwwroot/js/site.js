/*Constant declaration*/
const orderUri = "api/v1/ProductOrder";
const offerUri = "api/v1/ProductStock";
const getTopFiveMerchantProductsUri = orderUri + "/GetTopFiveProductDetails";
const updateStockUri = offerUri + "/UpdateStockData";

/*This Method calls the model*/
function showToast(text) {
    $("#toast").find('.modal-body').html(text);
    $("#toast").modal('toggle');
}

/*This function sends requests to API and bind json data to the table and dropdown */
function getTopFiveOrderData() {
    fetch(getTopFiveMerchantProductsUri) // calls API to get all the orders with status in progress
        .then(function (response) {
            return response.json();
        }).then(function (JsonData) {
            console.log(JsonData);
            renderDataInTheTable(JsonData) //Method call for creating table
            return JsonData;
        }).then(function (data) {
            let option;
            let dropdown = document.getElementById('productnumber-dropdown'); // binding data to the dropdown
            dropdown.length = 0;
            for (let i = 0; i < data.length; i++) {
                option = document.createElement('option');
                option.text = data[i].productNumber;
                option.value = data[i].productNumber;
                dropdown.add(option);
            }
        }).catch(error => showToast('Unable to get items.<br>' + JSON.stringify(error)))
}

/*This method binds the data to the table */
function renderDataInTheTable(JsonData) {
    const mytable = document.getElementById("html-data-table");
    JsonData.forEach(JsonData => {
        let newRow = document.createElement("tr");
        Object.values(JsonData).forEach((value) => {
            let cell = document.createElement("td");
            cell.innerText = value;
            newRow.appendChild(cell);
        });
        mytable.appendChild(newRow);
    });
}

/*This function sends requests to API to update the stock */
function updateStock(productNumber) {
    fetch(updateStockUri, {
        method: 'PUT',
        headers: {
            'Accept': 'application/json',
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            MerchantProductNo: productNumber,
            Stock: 25
        })}).then(() => {
        $("#editStockModal").modal('toggle');
        showToast('Stock of product number ' + productNumber + ' has been successfully updated.');
    }).catch(error => showToast('Unable to update item.<br>' + JSON.stringify(error)));
}

/*This function takes the latest product number selected by user */
function updatebtnClick() {
    var selectednum = $("select.products").children("option:selected").val();
    updateStock(selectednum);
}

