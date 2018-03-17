
//for further reference
/*$(function () {
   $(".increment").click(function () {
      var count = parseInt($("~ .count", this).text());
     if ($(this).hasClass("up")) {
        var count = count +    1;
            $("~ .count", this).text(count);
        } else {
           var count = count - 1;
          $("~ .count", this).text(count);       }

       $(this).parent().addClass("bump");        setTimeout(function () {
            $(this).parent().removeClass("bump");
       }, 400);
  });
});*/
//for further reference
/*var counter = 0,
  votePlus = counter + 1,
  voteMinus = counter - 1;

function checkIfUserVoted() {
    return localStorage.getItem("voted");
}
if (!localStorage.getItem("voted")) {
    localStorage.setItem("voted", counter);
    $("~ .count").text(counter);
}
$(".increment").click(function () {
    var id = $(this).attr('id');
    var finalcount;
    if ($(this).hasClass("up")) {
       
        
        var vote = checkIfUserVoted() != votePlus ? votePlus : counter;
        localStorage.setItem("voted", vote);
        $("~ .count", this).text(vote);
        finalcount = vote;
    }
    else {
       
        var vote = checkIfUserVoted() != voteMinus ? voteMinus : counter;
        localStorage.setItem("voted", vote);
        $("~ .count", this).text(vote);
        finalcount = vote;
    }
    UpdateVote(id,finalcount)
  
   
});*/
var counter = 0,
  votePlus = counter - 1,
  voteMinus = counter + 1;

function checkIfUserVoted() {
    return localStorage.getItem("voted");
}
if (!localStorage.getItem("voted")) {
    localStorage.setItem("voted", counter);
    $("~ .count").text(counter);
}
$(".increment").click(function () {
    var id = $(this).attr('id');
    var finalcount;
    if ($(this).hasClass("up")) {


        var vote = checkIfUserVoted() != votePlus ? votePlus : voteMinus;
        localStorage.setItem("voted", vote);
        $("~ .count", this).text(vote);
        finalcount = vote;
    }
    else {

        var vote = checkIfUserVoted() != voteMinus ? voteMinus : votePlus;
        localStorage.setItem("voted", vote);
        $("~ .count", this).text(vote);
        finalcount = vote;
    }
    UpdateVote(id, finalcount)


});
function AuthenticateUser(x, y, z) {

    if (sessionStorage.getItem('foo') != null) {
        $.ajax({
            type: "POST",
            url: '/Answer/GetAnswers',
            data: { qNO: x, qTitle: y, qDesc: z },
            complete: function (result) {
                if (result.responseText) {
                    $('body').html(result.responseText);
                }
            }
        });

        console.log(y);
    }
    else {
        console.log("asdas")
        $('#loginModal').modal('show');

    }

}
function CheckLogin() {
    alert("log");
    var username = document.getElementById("logemail").value;
    var password = document.getElementById("logpwd").value;
    $.ajax({
        type: "POST",
        url: '/Answer/CheckLogin',
        data: { username, password },
        complete: function (result) {
            if (result.responseText == 'True') {
                alert("Login Succes");
                sessionStorage.setItem('foo', 'bar');
                $('#loginModal').modal('hide');
            }
            else {
                document.getElementById('valid').innerHTML = 'Please check your credentials';

            }

        }
    });

}
function UpdateVote(id, finalcount) {
    $.ajax({
        type: "POST",
        url: '/Answer/UpdateVote',
        data: { id, finalcount },
        complete: function (result) {
            if (result.responseText) {
                $("#" + id + ".voter").text(result.responseText);
                alert(result.responseText)
            }
            else {
                alert('sorry');

            }

        }
    });
}
function Clear() {
    alert("session clear");
    sessionStorage.clear();
}
function test() {
    alert(document.getElementById('').value);
}
$('button.btn').click(function () {
    var id = $(this).attr('id');
    alert(id)

});

/*window.setInterval(function () {

    $.ajax({
        type: "POST",
        url: '/Question/AllQuestions',
        complete: function (result) {

            if (result.responseText) {
                $('body').html(result.responseText);
            }

            else {
                alert('sorry');
            }
        }
    });
}, 60000);*/
window.setInterval(function () {
    alert("ajax");
    $.ajax({
        type: "POST",
        url: '/Question/TimeDifference',
        contentType: "application/json; charset=utf-8",
        dataType: 'json',
        complete: function (data) {
           
            //  alert(data.responseText)
            var a = JSON.parse(data.responseText);
           // var a = 
            alert(a[0].TimeDifference);
            //var jomon = JSON.parse(result);
            //alert(jomon[0].TimeDifference);
           //var len=Object.keys(result).length
          // alert(data);
           /* for (var i = 0; i < len; i++) {
                alert(result[i].TimeDifference);
            }*/
          
        }
    });
}, 10000);