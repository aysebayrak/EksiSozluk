$(document).ready(function () {
    $(".nav-link").click(function (e) {
        e.preventDefault();
        if (!$(this).hasClass("no-ajax")) {
            var categoryId = $(this).data("category-id");
            loadCategoryHeadings(categoryId);
        } else {
       var href = $(this).attr("href");
            window.location.href = href;
        }
    });
});
function loadCategoryHeadings(categoryId) {
    $("#headers").empty();
    $.ajax({
        url: "/Category/HeadingsByCategory",
        type: "GET",
        data: { categoryId: categoryId },
        success: function (data) {
            $("#headers").html(data);
        }
    });
}

//$(document).ready(function () {
//    $(".nav-link").click(function (e) {
//        e.preventDefault();

//        var categoryId = $(this).data("category-id");
//        loadCategoryHeadings(categoryId);
//    });
//});

//function loadCategoryHeadings(categoryId) {
//    $("#headers").empty();
//    $.ajax({
//        url: "/Category/HeadingsByCategory",
//        type: "GET",
//        data: { categoryId: categoryId },
//        success: function (data) {
//            $("#headers").html(data);
//        }
//    });
//}
