


var Utils = {
    getAppUserList: function getAppUserList() {
        NotifyService.getNotifyList()
            .then(function (data) {
                if (data != null) {
                    const div = document.getElementById('messageCount');
                    div.innerHTML = data.length;
                    data.forEach(item => {
                        const container = document.getElementById('container');
                        container.innerHTML = '';
                        data.forEach(item => {
                            var options = {
                                year: 'numeric', month: 'long', day: 'numeric', hour: 'numeric', minute: 'numeric'
                            }
                            var createdDate = new Date(item.createdDate);
                            var formattedDate = createdDate.toLocaleString("tr-TR", options);

                            const htmlCode = `<a class="dropdown-item d-flex align-items-center" href="/Home/TodoDetails/${item.todoId}"  target="_blank">
                                                    <div class="font-weight-bold">
                                                        
                                                        <div class="text-truncate">${item.appUserName} - Bildirdiklerinizden (${item.todoId}) Nolu Bildirim</div>
                                                        <div class="small">${item.assignedUserName} <span>${formattedDate}</span> </div>
                                                    </div>
                                                </a>`;
                            container.insertAdjacentHTML('beforeend', htmlCode);
                        });
                    })
                }
            });
    },
    getAssignedUserList: function getAssignedUserList() {
        NotifyService.getNotifyListAssigned()
            .then((datas) => {
                if (datas != null) {
                    const countDiv = document.getElementById('messageCountAssigned');
                    countDiv.innerHTML = datas.length;
                    const contentDiv = document.getElementById('container_assigned');
                    contentDiv.innerHTML = '';
                    datas.forEach(item => {
                        var options = { year: 'numeric', month: 'long', day: 'numeric', hour: 'numeric', minute: 'numeric' };
                        var createdDate = new Date(item.createdDate);
                        var formattedDate = createdDate.toLocaleString("tr-TR", options);

                        const contentHtmlCode = `<a  class="dropdown-item d-flex align-items-center" href="/Home/TodoDetails/${item.todoId}"  target="_blank">
                                                    <div class="font-weight-bold">  
                                                        <div class="text-truncate">${item.assignedUserName} - Size Atananlardan (${item.todoId}) Nolu Bildirim</div>
                                                        <div class="small">${item.appUserName} <span>${formattedDate}</span> </div>
                                                    </div>
                                                </a>`;
                        contentDiv.insertAdjacentHTML('beforeend', contentHtmlCode);

                    })
                }
            });
    }
}

Utils.getAppUserList();
Utils.getAssignedUserList();





$('#messagesDropdown').click(function () {
    Utils.getAppUserList();
})
$('#messagesDropdownAssigned').click(function () {
    Utils.getAssignedUserList();
})
$('#container_assigned').click(() => {
    setTimeout(() => {
        Utils.getAssignedUserList();
    }, 1000)

});
$('#container').click(() => {
    setTimeout(() => {
        Utils.getAppUserList();
    }, 1000)

});
