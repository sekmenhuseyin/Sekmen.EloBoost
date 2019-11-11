$(function () {
    var $theFrom = $('#AjaxForm');

    $theFrom.validate({
        highlight: function (input) {
            $(input).parents('.form-line').addClass('error');
        },
        unhighlight: function (input) {
            $(input).parents('.form-line').removeClass('error');
        },
        errorPlacement: function (error, element) {
            $(element).parents('.input-group').append(error);
        }
    });

    $theFrom.submit(function (e) {
        e.preventDefault();

        if (!$theFrom.valid()) {
            return;
        }

        abp.ui.setBusy(
            $('#FormArea'),

            abp.ajax({
                contentType: 'application/x-www-form-urlencoded',
                url: $theFrom.attr('action'),
                data: $theFrom.serialize()
            })
        );
    });
});
