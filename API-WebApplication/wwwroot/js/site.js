/*Constant declaration*/
const orderUri = "api/v1/ProductOrder";
const offerUri = "api/v1/ProductStock";
const getTopFiveMerchantProductsUri = orderUri + "/GetTopFiveProductDetails";
const updateStockUri = offerUri + "/UpdateStockData";

function getTopFiveOrderData() {
    fetch(getTopFiveMerchantProductsUri)
        .then(function (response) {
            return response.json();
        }).then(function (apiJsonData) {
            console.log(apiJsonData);
            renderDataInTheTable(apiJsonData);
            return apiJsonData;
        }).then(function (data) {
            let option;
            let dropdown = document.getElementById('productnumber-dropdown');
            dropdown.length = 0;

            for (let i = 0; i < data.length; i++) {
                option = document.createElement('option');
                option.text = data[i].productNumber;
                option.value = data[i].productNumber;
                dropdown.add(option);
        }}).catch(error => showToast('Unable to get items.<br>' + JSON.stringify(error)))
}

function renderDataInTheTable(JsonData) {
    const mytable = document.getElementById("html-data-table");
    JsonData.forEach(JsonData => {
        let newRow = document.createElement("tr");
        Object.values(JsonData).forEach((value) => {
            let cell = document.createElement("td");
            cell.innerText = value;
            newRow.appendChild(cell);
        })
        mytable.appendChild(newRow);
    });
}
function showToast(text) {
    $("#toast").find('.modal-body').html(text);
    $("#toast").modal('toggle');
}

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
        })
    }).then(() => {
        $("#editStockModal").modal('toggle');
        showToast('Stock of product number ' + productNumber + ' has been successfully updated.');

    }).catch(error => showToast('Unable to update item.<br>' + JSON.stringify(error)));
}

function myChange() {
    document.querySelector('#mybtn').disabled = false;
    var selectednum = $("select.country").children("option:selected").val();
    if (selectednum == "Choose Product Number") {
        document.querySelector('#mybtn').disabled = true;
    }
}

function myFunction() {
    var selectednum = $("select.products").children("option:selected").val();
    updateStock(selectednum);
}

