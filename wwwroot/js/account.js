// account.js

document.addEventListener("DOMContentLoaded", function () {

    const editToggleBtn = document.getElementById("editToggleBtn");
    const cancelEditBtn = document.getElementById("cancelEditBtn");
    const editFormSection = document.getElementById("editFormSection");

    function toggleForm(show) {
        if (!editFormSection) return;
        editFormSection.style.display = show ? "block" : "none";
    }

    if (editToggleBtn) {
        editToggleBtn.addEventListener("click", () => toggleForm(true));
    }

    if (cancelEditBtn) {
        cancelEditBtn.addEventListener("click", () => toggleForm(false));
    }

    document.querySelectorAll(".eye-btn").forEach(btn => {
        btn.addEventListener("click", () => {
            const target = document.querySelector(btn.dataset.target);
            if (!target) return;
            target.type = target.type === "password" ? "text" : "password";
        });
    });

    const hasErrorAttr = editFormSection?.dataset?.hasError; // "True" / "False" / undefined
    const hasError = hasErrorAttr === "True" || hasErrorAttr === "true";

    if (hasError) {
        toggleForm(true);
    }
});
