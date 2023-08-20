//$(document).ready(function () {
//    $(".nav-link").click(function (e) {
//        e.preventDefault();

//        // Eğer tıklanan linkin no-ajax sınıfı yoksa kategori başlıklarını yükle
//        if (!$(this).hasClass("no-ajax")) {
//            var categoryId = $(this).data("category-id");
//            loadCategoryHeadings(categoryId);
//        } else {
//            // no-ajax sınıfı varsa linki sayfa içeriğini yüklemek için kullan
//            var href = $(this).attr("href");
//            // Sayfa içeriğini yükleme fonksiyonunu burada çağırabilirsiniz
//            // Örnek olarak aşağıdaki gibi bir kod ekleyebilirsiniz
//            window.location.href = href;
//        }
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




$(document).ready(function () {
    $(".nav-link").click(function (e) {
        e.preventDefault();

        var categoryId = $(this).data("category-id");
        loadCategoryHeadings(categoryId);
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
