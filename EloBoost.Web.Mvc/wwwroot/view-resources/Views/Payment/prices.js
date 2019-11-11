$(document).ready(function () {
    //var kdv = 1.18;
    //function to calculate price
    function getPrice(pointsPerMatch, currentLeague, currentDivision, desiredLeague, desiredDivision) {
        var price = 0; var found = false;
        for (let index = 0; index < window.priceList.length; ++index) {
            if (found) {
                price += window.priceList[index][3];
            }
            if (window.priceList[index][0] === pointsPerMatch && window.priceList[index][1] === currentLeague && window.priceList[index][2] === currentDivision) {
                found = true;
            }
            if (window.priceList[index][0] === pointsPerMatch && window.priceList[index][1] === desiredLeague && window.priceList[index][2] === desiredDivision) {
                found = false;
            }
        }

        //return numeral(price * kdv).format('0,0') + " TL";
        $("#Price").val(price);
        return numeral(price).format('0,0') + " TL";
    }

    //league change
    $('.league').change(function (e, i) {
        var selected = this.selectedIndex;
        var logos = $(this).parents('.fboxContent').find('.badgeLig img');
        $(logos).hide();
        $(logos).eq(selected).fadeIn();
    });

    //cmd change
    $('#SourceLeagueTypes, #SourceDivisionTypes, #DestinationLeagueTypes, #DestinationDivisionTypes, #LeaguePoints').change(function (e, i) {
        $(".price").html(getPrice($("#LeaguePoints").val(), $("#SourceLeagueTypes").val(), $("#SourceDivisionTypes").val(), $("#DestinationLeagueTypes").val(), $("#DestinationDivisionTypes").val()));
    });
});