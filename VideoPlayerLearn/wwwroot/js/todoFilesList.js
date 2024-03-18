var TodoFilesList = TodoFilesList || {};


$(document).ready(() => {
    TodoFilesList.listFiles();
})

TodoFilesList.listFiles = function () {
    FileUpload.GetTodoFiles()
        .then((datas) => {
            if (datas != null) {
                const div = document.getElementById('fileListDiv');
                div.innerHTML = '';
                datas.forEach(data => {
                    const fileName = data.fileName;
                    const filePath = data.filePath;
                    const todoId = data.todoId;
                    const realFileName = data.realFileName;
                    
                    const htmlCode = `<i class="fa-solid fa-file-signature fa-lg"></i>
                    <a href = "https://localhost:7035/api/todofiles/download/${fileName}"  > ${realFileName}</a><br/>`;


                    div.insertAdjacentHTML('beforeend', htmlCode);

                })
            }
        })
}
//< div style = "font-size:13px;" > @Html.ActionLink('${realFileName}', "DownloadFile", new { Name = '${fileName}' }) < hr /></div >