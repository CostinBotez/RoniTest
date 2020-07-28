// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('.mark-as-complete').click(function () {

    var markAction = $(this);
    var jobRow = markAction.closest('tr');
    var jobId = markAction.data('job-id');

    $.ajax({
        url: '/Jobs/MarkAsComplete',
        type: 'POST',
        data: {
            id: jobId
        },
        success: function (response) {
            if (repsonse.status == 'success') {
                markAction.remove();
                jobRow.attr('class', 'table-success');
            } else {
                alert('Fail');
            }
        }
    })

});