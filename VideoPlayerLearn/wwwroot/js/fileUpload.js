$(document).ready(function () {
    $('#uploadButton').click(function () {
        var formData = new FormData();
        var files = $('#formFileSm')[0].files;

        for (var i = 0; i < files.length; i++) {
            formData.append('files', files[i]);
        }

        formData.append('id', $('#TodoId').val());

        $.ajax({
            url: '/api/TodoFiles/' + $('#TodoId').val(),
            type: 'POST',
            data: formData,
            processData: false,
            contentType: false,
            success: function (response) {
                TodoCommentService.fileUploadAfterComment(response)
                    .then(() => {
                        TodoCommentUseView.fileUploadAfterCommentList();
                    })
                console.log(response);
            },
            error: function (xhr, status, error) {
                console.error(error);
            }
        });
        return false;
    });
});