$(document).ready(function() {

    
    var toggleImage = $(".toggleImage");
    toggleImage.on("click", function () {
        console.log("clicked");
        $(this).next(".eventImage").toggle(500);
        //if (toggleImage.text() === "Show") toggleImage.text("Hide");
        //else toggleImage.text("Show");
    });

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

    $(".toggleBet").on("click",function(e) {
        $(this.parentNode).toggleClass("open");
    });
});