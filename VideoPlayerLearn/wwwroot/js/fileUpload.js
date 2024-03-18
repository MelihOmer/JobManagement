var FileUpload = FileUpload || {};
$(document).ready(function () {

    FileUpload.GetTodoFiles()

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
                        TodoFilesList.listFiles();
                    })
                //console.log(response);
            },
            error: function (xhr, status, error) {
                console.error(error);
            }
        });
        return false;
    });
});

FileUpload.GetTodoFiles = function () {
    return new Promise(function (resolve, rejected) {
        $.ajax({
            url: '/api/TodoFiles/' + $('#TodoId').val(),
            type: 'GET',
            dataType: 'json',
            success: function (datas) {
                if (datas && datas.length > 0) {
                    resolve(datas);
                    datas.forEach((data) => {
                        //console.log(data.fileName + " " + data.realFileName)
                    })
                }
            },
            error: function (xhr, status, error) {

                console.error("Dosyalar Getirilirlen Hata Oluþtu : ", xhr);
                rejected();
            }

        })
    }
)}