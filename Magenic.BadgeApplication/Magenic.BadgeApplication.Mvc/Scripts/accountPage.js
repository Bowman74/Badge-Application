﻿$(document).ready(function () {
    // TODO: can we get this to work with knockout?
    onSuccess();
});

function onSuccess() {
    $('.slider').slider()
        .on('slideStop', function (e) {
            $(this).closest('form').submit();
        });
}
