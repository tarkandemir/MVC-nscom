function RegisterFormResult(data, status, xhr) {
    if (data.StatusCode == 0) {
        alert("Üyeliğiniz kaydedildi. Açılacak sayfa üzerinden giriş yapabilirsiniz.");
        document.location.href = "/giris";
    }
    else alert(data.StatusMessage);
}
// ---------------------------------------------------------
function LoginFormResult(data, status, xhr) {
    if (data.StatusCode == 0) {
        //RefreshTopLinks();
        document.location.href = "/";
    }
    else alert(data.StatusMessage);
}
// ---------------------------------------------------------
function ContactFormResult(data, status, xhr) {
    if (data.StatusCode == 0) {
        alert("Mailiniz tarafımıza ulaştı. En yakın zamanda iletişime geçeceğiz.");
        document.location.href = "/";
    }
    else alert(data.StatusMessage);
}
// ---------------------------------------------------------
function UpdateFormResult(data, status, xhr) {
    if (data.StatusCode == 0) {
        alert("Güncelleme başarılı!");
        document.location.href = document.location.href;
    }
    else alert(data.StatusMessage);
}
// ---------------------------------------------------------
function LostPasswordFormResult(data, status, xhr) {
    if (data.StatusCode == 0) {
        alert("Şifre sıfırlama maili sistemde tanımlı mail adresinize gönderilmiştir.");
        document.location.href = "/giris";
    }
    else alert(data.StatusMessage);
}
// ---------------------------------------------------------
function NewsletterFormResult(data, status, xhr) {
    if (data.StatusCode == 0) {

        if (data.Data.IS_NEWSLETTER) alert("E-Bülten servisine hoşgeldiniz!");
        else alert("E-Bülten servisinden çıktınız!");
    }
    else alert(data.StatusMessage);
}
// ---------------------------------------------------------
function RefreshTopLinks() {
    $.ajax({
        url: "/Partial/TopLinks",
        type: "GET",
        dataType: "html",
        success: function (data) {
            $("#topLinks").html(data);
        }
    });
}
// ---------------------------------------------------------
function RefreshCartDropDown() {
    $.ajax({
        url: "/Partial/CartDropdown",
        type: "GET",
        dataType: "html",
        success: function (data) {
            $("#topCart").html(data);
        }
    });
}

$(document).ready(function () {
    $('#formAccount').ajaxForm({
        success: UpdateFormResult
    });
});