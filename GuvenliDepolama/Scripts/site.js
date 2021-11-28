site = {
    init: function () {
        $("#btnLogin").click(function (e) {
            e.preventDefault();
            var param = {
                Mail: $("#email").val(),
                Password: $("#password").val()
            }
            
            $.ajax({
                type: "POST",
                url: "/Secure/Login",
                data: param,
                success: function (v) {
                    if (v.isOk) {
                        location.href = "/Home";
                       //alert("Login işlemi başarılı");
                    }
                    else
                        alert("Mail veya şifre hatalı");
                },
                error: function () {
                    alert("Beklenmeyen bir hata meydana geldi.");
                }
            });
        });

        $("#btnSignIn").click(function (e) {
            e.preventDefault();
            debugger;
            var param = {
                Name: $("#name").val(),
                SurName: $("#surname").val(),
                Mail: $("#email").val(),
                Password: $("#password").val()
            }
            debugger;
            $.ajax({
                type: "POST",
                url: "/Secure/SignIn",
                data: param,
                success: function (v) {
                    debugger;
                    if (v.isOk)
                        alert("kayıt işlemi başarılı");
                    else
                        alert(v.Msj);
                },
                error: function () {
                    alert("Beklenmeyen bir hata meydana geldi.");
                }
            });
        });

    }
};

$(function () {
    site.init();
});

