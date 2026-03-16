document.querySelectorAll('.card-actions .btn').forEach(function (btn) {

    btn.addEventListener('click', function (e) {

        e.preventDefault();

        const card = this.parentElement.previousElementSibling;

        card.classList.add("export-card");

        html2canvas(card, {
            scale: 2,
            useCORS: true,
            backgroundColor: null
        }).then(function (canvas) {

            card.classList.remove("export-card");

            const link = document.createElement("a");
            link.download = "card.png";
            link.href = canvas.toDataURL("image/png");
            link.click();

        });

    });

});