function updatePrice() {
    let membership = document.getElementById("membership").value;
    let subtotal = document.getElementById("subtotal");
    let finalTotal = document.getElementById("finalTotal");

}

function applyDiscount() {
    let discountCode = document.getElementById("discountCode").value;
    let subtotalText = document.getElementById("subtotal").innerText.replace("$", "");
    let finalTotal = document.getElementById("finalTotal");

    if (!isNaN(subtotalText) && discountCode === "DISCOUNT10") {
        let newTotal = (parseInt(subtotalText) * 0.9).toFixed(2);
        finalTotal.innerHTML = `$${newTotal}`;
    } else if (discountCode !== "DISCOUNT10") {
        alert("Invalid discount code!"); <script>
            document.addEventListener('DOMContentLoaded', function () {
        const membershipSelect = document.getElementById('membership');
            const durationSelect = document.getElementById('duration');
            const subtotalElement = document.getElementById('subtotal');
            const totalElement = document.getElementById('finalTotal');
            const applyDiscountBtn = document.getElementById('applyDiscountBtn');

            function updatePrice() {
            const membershipPrice = parseFloat(membershipSelect.value) || 0;
            const duration = parseInt(durationSelect.value) || 1;
            const subtotal = membershipPrice * duration;

            subtotalElement.innerText = '$' + subtotal.toFixed(2);
            totalElement.innerText = '$' + subtotal.toFixed(2);
        }

            function applyDiscount() {
                let discountCode = document.getElementById("discountCode").value;
            let subtotalText = document.getElementById("subtotal").innerText.replace("$", "");
            let finalTotal = document.getElementById("finalTotal");

            if (!isNaN(subtotalText) && discountCode === "DISCOUNT10") {
                let newTotal = (parseFloat(subtotalText) * 0.9).toFixed(2);
            finalTotal.innerHTML = `$${newTotal}`;
            } else if (discountCode !== "DISCOUNT10") {
                alert("Invalid discount code!");
            }
        }

        // Event Listeners
        membershipSelect.addEventListener('change', updatePrice);
        durationSelect.addEventListener('change', updatePrice);
        applyDiscountBtn.addEventListener('click', applyDiscount);

        updatePrice(); // Initialize on load
    });
</script>

    }
}

document.addEventListener('DOMContentLoaded', function () {

    const membershipSelect = document.getElementById('membership');

    const urlParams = new URLSearchParams(window.location.search);
    const selectedMembership = urlParams.get('membership');

    if (selectedMembership) {
        membershipSelect.value = selectedMembership;

    function updatePrice() {
        const membershipPrice = parseFloat(membershipSelect.value);
        const duration = parseInt(durationSelect.value);

        if (isNaN(membershipPrice) || isNaN(duration)) return;

        const subtotal = membershipPrice * duration;

        subtotalElement.innerText = '$' + subtotal.toFixed(2);
        totalElement.innerText = '$' + subtotal.toFixed(2);
    }

    membershipSelect.addEventListener('change', updatePrice);
    durationSelect.addEventListener('change', updatePrice);

    updatePrice();
});


