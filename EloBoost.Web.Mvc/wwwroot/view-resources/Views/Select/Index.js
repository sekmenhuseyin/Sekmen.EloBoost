(function() {
    $(function() {

        $('#RefreshButton').click(function () {
            refreshList();
        });

        $('.btnStart').click(function () {
            var id = $(this).attr("data-id");

            abp.ui.setBusy(
                $('#AjaxForm'),

                abp.ajax({
                    contentType: 'application/x-www-form-urlencoded',
                    url: abp.appPath + 'Select/StartOrder/' + id
                })
            );
        });

        $('.btnFinish').click(function () {
            var id = $(this).attr("data-id");

            abp.ui.setBusy(
                $('#AjaxForm'),

                abp.ajax({
                    contentType: 'application/x-www-form-urlencoded',
                    url: abp.appPath + 'Select/FinishOrder/' + id
                })
            );
        });

        function refreshList() {
            location.reload(true);
        }
    });
})();