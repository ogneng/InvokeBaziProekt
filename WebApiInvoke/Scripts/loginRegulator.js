$(document).ready(function() {
    $("#login").click(function(e) {
        // e.preventDefault();
        var usernameInput = $("input[name='username']");
        var passwordInput = $("input[name='password']");
        var hadError = false;
        if (usernameInput.val() == "") {
            if (!usernameInput.hasClass('error')) {
                usernameInput.addClass('error');
                setTimeout(function() {
                    usernameInput.removeClass('error');
                }, 1000)
            }
            hadError = true;

        }
        if (passwordInput.val() == "") {
            if (!passwordInput.hasClass('error')) {
                passwordInput.addClass('error');
                setTimeout(function() {
                    passwordInput.removeClass('error');
                }, 1000);
            }
            hadError = true;
        }

        if (hadError) {
            return false;
        } else {
            return true;
        }
    });

    $("#showSignUp").click(function(e){
        e.preventDefault();
        var signUpForm = $('#signUpForm');
        var loginForm = $('#loginForm');

        loginForm.removeClass('visible');
        loginForm.addClass('hidden');
        signUpForm.addClass('visible');
        signUpForm.removeClass('hidden');
    });
    $("#signUp").click(function(e){

    });
    $("#backToLogin").click(function(e){
        var signUpForm = $('#signUpForm');
        var loginForm = $('#loginForm');

        signUpForm.removeClass('visible');
        signUpForm.addClass('hidden');

        loginForm.removeClass('hidden');
        loginForm.addClass('visible');
    });

})