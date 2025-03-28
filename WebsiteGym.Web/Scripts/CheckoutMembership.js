function updatePrice() {
    // Preluăm valorile din select-uri
    let membership = document.getElementById("membership").value;
    let duration = document.getElementById("duration").value;

    // Elementele pentru Subtotal și Total
    let subtotal = document.getElementById("subtotal");
    let finalTotal = document.getElementById("finalTotal");

    // Debugging - Verificăm valorile
    console.log("Selected membership price: " + membership);
    console.log("Selected duration: " + duration);

    // Dacă nu sunt selectate sau sunt invalide, se setează subtotal și total la 0
    if (!membership || !duration || isNaN(membership) || isNaN(duration)) {
        subtotal.innerHTML = "$0";
        finalTotal.innerHTML = "$0";
        return;
    }

    // Prețul pachetului ales
    let price = parseInt(membership);

    // Calcularea totalului în funcție de durata selectată
    let totalPrice = price * parseInt(duration);

    // Debugging - Verificăm totalul calculat
    console.log("Calculated total price: " + totalPrice);

    // Actualizarea subtotalului și totalului
    subtotal.innerHTML = "$" + totalPrice;
    finalTotal.innerHTML = "$" + totalPrice;
}

// Aplicarea discountului
function applyDiscount() {
    let discountCode = document.getElementById("discountCode").value;
    let subtotalText = document.getElementById("subtotal").innerText.replace("$", "");
    let finalTotal = document.getElementById("finalTotal");

    // Verificăm dacă subtotalul este valid și codul discountului
    if (!isNaN(subtotalText) && discountCode === "DISCOUNT10") {
        let newTotal = (parseInt(subtotalText) * 0.9).toFixed(2);
        finalTotal.innerHTML = "$" + newTotal;
    } else if (discountCode !== "DISCOUNT10") {
        alert("Invalid discount code!");
    }
}
