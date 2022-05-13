$(function () {

    //if ($("a.confirmDeletion").length){
    //    $("a.confirmDeletion").click(() => {
    //        if (!confirm("confirmDeletion")) return false;
    //    });
    //}
    if ($("div.alert.notification").length){
        setTimeout(() => {
            $("div.alert.notification").fadeOut();

        }, 2000);
    }


    //$('#showPass').on('click', function () {
    //    var password = $("#passInput");
    //    if (password.attr('type') === 'password') {
    //        password.attr('type', 'text');
    //    } else {
    //        password.attr('type', 'password');
    //    }
    //})
});