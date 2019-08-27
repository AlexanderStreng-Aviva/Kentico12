document.addEventListener("DOMContentLoaded", function() {
    var sidenavElement = document.querySelector(".sidenav");
    M.Sidenav.init(sidenavElement);
    var dropdownElement = document.querySelector(".dropdown-trigger");

    M.Dropdown.init(dropdownElement, {
        hover: false
    });
});


/*
  /* Contact us page - Google map 
  function medioClinicMap(){

    var myLatLng = { lat: 51.5, lng: -0.15};

    var mapOptions = {
        zoom: 10,
        center: myLatLng,
        mapTypeId: google.maps.MapTypeId.HYBRID
    };
    
    var map = new google.maps.Map(document.getElementById("map"), mapOptions);

    var marker = new google.maps.Marker({
        position: myLatLng,
        map: map
    });

    var devwindow = new google.maps.InfoWindow({
        content: "Example location"
    });

    devwindow.open(map, marker);
}
*/

// $(function () {
//     // sidenav
//     $('.sidenav').sidenav();

//     // languages dropdown
//     $(".dropdown-trigger").dropdown({
//         hover: false
//     });
// });


  /* Contact us page - Google map */
//   function initMap() {

//     var mapOptions = {
//         zoom: 3,
//         center: { lat: 0, lng: 0 },
//         mapTypeId: google.maps.MapTypeId.HYBRID
//     };
    
//     var map = new google.maps.Map(document.getElementById("map"), mapOptions);

//     var marker = new google.maps.Marker({
//         position: {
//             lat: 51.5,
//             lng: -0.15,
//         },
//         map: map
//     });

//     marker.setMap(map);

//     var InfoWindow = new google.maps.InfoWindow({
//         content: "Example location"
//     });

//     InfoWindow.open(map, marker);
// }
