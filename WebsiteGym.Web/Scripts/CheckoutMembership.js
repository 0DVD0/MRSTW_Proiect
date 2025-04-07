function updatePrice() {

    let membership = document.getElementById("membership").value;
    let duration = document.getElementById("duration").value;

    let subtotal = document.getElementById("subtotal");
    let finalTotal = document.getElementById("finalTotal");

    console.log("Selected membership price: " + membership);
    console.log("Selected duration: " + duration);

    if (!membership || !duration || isNaN(membership) || isNaN(duration)) {
        subtotal.innerHTML = "$0";
        finalTotal.innerHTML = "$0";
        return;
    }

    let price = parseInt(membership);
    let totalPrice = price * parseInt(duration);

    console.log("Calculated total price: " + totalPrice);

    subtotal.innerHTML = "$" + totalPrice;
    finalTotal.innerHTML = "$" + totalPrice;
}

function applyDiscount() {
    let discountCode = document.getElementById("discountCode").value;
    let subtotalText = document.getElementById("subtotal").innerText.replace("$", "");
    let finalTotal = document.getElementById("finalTotal");

    if (!isNaN(subtotalText) && discountCode === "DISCOUNT10") {
        let newTotal = (parseInt(subtotalText) * 0.9).toFixed(2);
        finalTotal.innerHTML = "$" + newTotal;
    } else if (discountCode !== "DISCOUNT10") {
        alert("Invalid discount code!");
    }
}

document.addEventListener("DOMContentLoaded", function () {
    const cardInput = document.getElementById("CardNumber");
    const expInput = document.getElementById("ExpDate");

    if (cardInput) {
        cardInput.addEventListener("input", function () {
            let value = this.value.replace(/\D/g, ''); 
            if (value.length > 16) {
                value = value.slice(0, 16); 
            }
            this.value = value.replace(/(\d{4})(?=\d)/g, '$1 '); 
        });
    }

    if (expInput) {
        expInput.addEventListener("input", function () {
            let value = this.value.replace(/\D/g, ''); 
            if (value.length > 4) {
                value = value.slice(0, 4); 
            }
            if (value.length >= 3) {
                this.value = value.slice(0, 2) + '/' + value.slice(2);
            } else {
                this.value = value;
            }
        });
    }
});


