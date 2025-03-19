function updatePrice() {
    let membership = document.getElementById("membership").value;
    let subtotal = document.getElementById("subtotal");
    let finalTotal = document.getElementById("finalTotal");

    if (membership === "negotiable") {
        subtotal.innerHTML = "Negotiable";
        finalTotal.innerHTML = "Negotiable";
    } else {
        let price = parseInt(membership);
        subtotal.innerHTML = `$${price}`;
        finalTotal.innerHTML = `$${price}`;
    }
}

function applyDiscount() {
    let discountCode = document.getElementById("discountCode").value;
    let subtotalText = document.getElementById("subtotal").innerText.replace("$", "");
    let finalTotal = document.getElementById("finalTotal");

    if (!isNaN(subtotalText) && discountCode === "DISCOUNT10") {
        let newTotal = (parseInt(subtotalText) * 0.9).toFixed(2);
        finalTotal.innerHTML = `$${newTotal}`;
    } else if (discountCode !== "DISCOUNT10") {
        alert("Invalid discount code!");
    }
}

