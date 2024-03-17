var TodoCommentService = TodoCommentService || {};
var Config = Config || {};

TodoCommentService.getTodoCommentList = function (todoId) {
    return new Promise(function (resolve, reject) {
        $.ajax({
            type: "GET",
            url: `${Config.commentListTodo}${todoId}`,//'https://localhost:7035/api/todocomment/todo-comments/25', //Config.commentListTodo + todoId,
            dataType: "json",
            cache: false,
            success: function (data) {


                if (data != null) {
                    resolve(data);
                }
            },
            error: function (xhr) {
                console.error('Mesaj Getirmede Hata : ' + xhr.status);
            }
        })
    })
}
TodoCommentService.postTodoComment = function () {
    return new Promise(function (resolve, rejected) {
        $('#todoCommentAddForm').off('submit').on('submit', function (e) {
            e.preventDefault();
            var todoCommentDto = {
                Definition: $("#Definition").val(),
                TodoId: $("#TodoId").val(),
                AppUserId: $("#AppUserId").val(),
                AssignedToUserId: $("#AssignedToUserId").val()
            };

            $.ajax({
                url: `https://localhost:7035/api/todocomment/`,
                method: 'POST',
                data: JSON.stringify(todoCommentDto),
                contentType: 'application/json',
                success: function (response) {
                    resolve();
                },
                error: function (xhr, status, error) {
                    console.error('hata olustu : ', error);
                    console.log(todoCommentDto);
                    rejected(); // Hata oluþtuðunda promise'i reddet
                }
            })
        })
    })
}

//TodoCommentService.postTodoComment = function () {
//    return new Promise(function (resolve, rejected) {
//    $('#todoCommentAddForm').submit(function (e) {
//        e.preventDefault();
//        var todoCommentDto = {
//            Definition: $("#Definition").val(),
//            TodoId: $("#TodoId").val(),
//            AppUserId: $("#AppUserId").val(),
//            AssignedToUserId: $("#AssignedToUserId").val()
//        };
        

//            $.ajax({
//                url: `https://localhost:7035/api/todocomment/`,
//                method: 'POST',
//                data: JSON.stringify(todoCommentDto),
//                contentType: 'application/json',
//                success: function (response) {
//                    resolve();
//                },
//                error: function (xhr, status, error) {
//                    console.error('hata olustu : ', error);
//                    console.log(todoCommentDto);
//                }
//            })
//        })
//    })

//}