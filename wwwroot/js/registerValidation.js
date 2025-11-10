document.addEventListener('DOMContentLoaded', () => {
    const form = document.querySelector('form');
    const usernameInput = form.querySelector('input[name="userName"]');
    const emailInput = form.querySelector('input[name="userEmail"]');
    const passwordInput = form.querySelector('input[name="userPassword"]');

    form.addEventListener('submit', (e) => {
        const username = usernameInput.value.trim();
        const email = emailInput.value.trim();
        const password = passwordInput.value;

        const isUsernameValid = username.length >= 4;
        const isPasswordValid = password.length >= 8 && /\d/.test(password);

        const emailPattern = /^[A-Za-z0-9._%+-]+@student\.sdu\.dk$/i;
        const isEmailValid = emailPattern.test(email);

        if (!isUsernameValid || !isEmailValid || !isPasswordValid) {
            e.preventDefault();

            let message = 'Please fix the following:\n';
            if (!isUsernameValid) message += '- Username must be at least 4 characters\n';
            if (!isEmailValid) message += '- Email must be a valid @student.sdu.dk address\n';
            if (!isPasswordValid) message += '- Password must be at least 8 characters and contain at least one number\n';

            alert(message);
            }
        });
});