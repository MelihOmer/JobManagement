var TodoCommentUseView = TodoCommentUseView || {};
var scriptElement = document.getElementById('todoCommentScript');
var todoId = scriptElement.getAttribute('todoId');
//console.log("Gonderilen Id = ", todoId);

commentListUseView(todoId);
$(document).ready(() => {
   
})


$("#btnTodoCommentAdd").click(() => {
    definition = $("#Definition").val();
    TodoCommentService.postTodoComment(definition)
    setTimeout(() => {
       //comment imputu temizle ve commentleri listele
        $("#Definition").val('');
        commentListUseView(todoId);
    }, 100)

})


function commentListUseView(todoId) {
    TodoCommentService.getTodoCommentList(todoId)
        .then(function (data) {
            if (data != null) {
                const div = document.getElementById('todoCommentDiv');
                div.innerHTML = '';
                data.forEach(item => {
                    const imagePath = item.imagePath;
                    const fullName = item.fullName;
                    const definition = item.definition;
                    const createdDate = new Date(item.createdDate).toLocaleDateString('tr-TR', { day: '2-digit', month: '2-digit', year: 'numeric', hour: '2-digit', minute: '2-digit' });

                    const htmlCode = `
                <div  style="background:#fff; display:flex; align-items:flex-start;gap:20px;padding:20px; height:fit-content; position:relative">
                <img src="${imagePath}" style="width:60px; height:60px;border-radius:50%; border:2px solid #111;  " alt="1234a" />
                        <div style="background:#F5F6FA;position:absolute;width:6px;height:45%;left:47px;top:80px; margin:auto;"></div>
                        <div style="position:absolute; border-right:10px solid #F5F6FA; border-top:10px solid transparent;border-bottom:10px solid transparent; left:80px;top:40px"></div>
                        <div style="width:70%; background:#F5F6FA;padding:10px;">
                            <div style="font-size:18px;color:#6AB6AE;display:'flex'; align-items:center;gap:5px;margin-bottom:10px;font-weight:600;">${fullName} <span style="font-size:14px; color:#111;transform:translateY(2px);font-weight:400;">${createdDate}</span></div>
                            <div style="display:flex; align-items:center; gap:10px;margin-bottom:10px; width:fit-content;height:fit-content;"><span style="font-size:15px">${definition}</span> </div>
                        </div>
                        </div>`;
                    div.insertAdjacentHTML('beforeend', htmlCode);
                })
            }
        })
}
TodoCommentUseView.fileUploadAfterCommentList = function () {
    TodoCommentService.getTodoCommentList(todoId)
        .then(function (data) {
            if (data != null) {
                const div = document.getElementById('todoCommentDiv');
                div.innerHTML = '';
                data.forEach(item => {
                    const imagePath = item.imagePath;
                    const fullName = item.fullName;
                    const definition = item.definition;
                    const createdDate = new Date(item.createdDate).toLocaleDateString('tr-TR', { day: '2-digit', month: '2-digit', year: 'numeric', hour: '2-digit', minute: '2-digit' });

                    const htmlCode = `
                <div  style="background:#fff; display:flex; align-items:flex-start;gap:20px;padding:20px; height:fit-content; position:relative">
                <img src="${imagePath}" style="width:60px; height:60px;border-radius:50%; border:2px solid #111;  " alt="1234a" />
                        <div style="background:#F5F6FA;position:absolute;width:6px;height:45%;left:47px;top:80px; margin:auto;"></div>
                        <div style="position:absolute; border-right:10px solid #F5F6FA; border-top:10px solid transparent;border-bottom:10px solid transparent; left:80px;top:40px"></div>
                        <div style="width:70%; background:#F5F6FA;padding:10px;">
                            <div style="font-size:18px;color:#6AB6AE;display:'flex'; align-items:center;gap:5px;margin-bottom:10px;font-weight:600;">${fullName} <span style="font-size:14px; color:#111;transform:translateY(2px);font-weight:400;">${createdDate}</span></div>
                            <div style="display:flex; align-items:center; gap:10px;margin-bottom:10px; width:fit-content;height:fit-content;"><span style="font-size:15px">${definition}</span> </div>
                        </div>
                        </div>`;
                    div.insertAdjacentHTML('beforeend', htmlCode);
                })
            }
        })
}

