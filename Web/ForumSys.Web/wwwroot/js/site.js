// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

const error = document.getElementById('errorField');
const upVote = async (postId) => {
    var json = {
        postId: postId,
        isUpVote: true
    };

    var token = $("#votesForm input[name=__RequestVerificationToken]").val();

    $.ajax({
        url: "/api/votes",
        type: "POST",
        data: JSON.stringify(json),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: { 'X-CSRF-TOKEN': token },
        success: function (data) {
            $("#votesCount").html(data.votesCount);

            let up = document.getElementById("upVoteIcont");
            up.setAttribute("class", "fa fa-thumbs-up text-warning hover-button-type");

            let down = document.getElementById("downVoteIcont");

            down.setAttribute("class", "fa fa-thumbs-down text-primary hover-button-type");
            error.innerHTML = "";
        },
        error: function (err) {
            error.innerHTML = "Must be logged";
        }
    })

}
const downVote = (postId) => {
    var json = {
        postId: postId,
        isUpVote: false
    };

    var token = $("#votesForm input[name=__RequestVerificationToken]").val();

    $.ajax({
        url: "/api/votes",
        type: "POST",
        data: JSON.stringify(json),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        headers: { 'X-CSRF-TOKEN': token },
        success: function (data) {
            //    $("#votesCount").html("0");
            //} else {
            $("#votesCount").html(data.votesCount);

            document.getElementById("upVoteIcont").setAttribute("class", "fa fa-thumbs-up text-primary hover-button-type");

            document.getElementById("downVoteIcont").setAttribute("class", "fa fa-thumbs-down text-warning hover-button-type");
            error.innerHTML = "";
        },
        error: function (err) {
            error.innerHTML = "Must be logged";
        }
    })
}
