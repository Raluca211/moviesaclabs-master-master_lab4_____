


var button1 = $("#b1");
var value;
var del;

var button2 = $("#b2");



$('body').on('click', '.delete', function (event) {
    console.log('abccc');
    del = event.currentTarget.closest("li");
    del.remove();

});

button1.click(function() {
    
    value = $("#input1").val();
    $("#list").append("<li>"+value+"<button class='delete' type='button' style='margin-left:10px'>Remove!</button></li>");
   

});




button2.click(function () {

    jQuery.get("http://localhost:58431/api/Movies", function (data, status) {
        console.log(data);
    });
    

   


});