/// <reference path="../syn.delete-confirmation.js" />

$(function () {
    //$('[data-delete-button="true"]').on('click', function (e) {
    //    var currentRow = $(this).closest('tr');
    //    var url = $(this).attr('href');
    //    e.preventDefault();
    //    if (confirm('Are you sure that you want to delete this record?')) {
    //        $.ajax({
    //            url: url,
    //            type: 'POST',
    //            success: function (data) {
    //                if (data === 'OK')
    //                {
    //                    $(currentRow).hide();
    //                }
    //            },
    //            error: function (error) {
    //                alert('An error has occured: ' + error);
    //            }
    //        });
    //    };
    //});

    $('[data-delete-button="true"]').each(function () {
        var $deleteButton = $(this);
        var currentRow = $deleteButton.closest('tr');
        $deleteButton.deleteConfirmation(function () {
            $(currentRow).hide();
        });
    });
});