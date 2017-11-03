$(document).ready(function () {




    //var searchBar = $("#searchBar");
    //var toggleSearch = $("#toggleSearch");
    //toggleSearch.click(function () {
    //    console.log("searchBar clicked");
    //    searchBar.toggle(500);
    //});

    //var toggleBet = $(".toggleBet");
    //toggleBet.on("click", function () {
    //    console.log("bet clicked");
    //    $(this).nextAll(".betContent:first").slideToggle("slow");
    //});


    $('input').iCheck({
        checkboxClass: 'icheckbox_polaris',
        radioClass: 'iradio_polaris',
        
    });



    $(".toggleBet").on("click", function (e) {
        $(this.parentNode.parentNode).toggleClass("open");
    });
});