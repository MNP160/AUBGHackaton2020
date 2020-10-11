function addMarkersAndSetViewBounds() {
  // create map objects
  var bachinovo = new H.map.Marker({lat:42.029507,  lng:23.108302}),
      cityPark = new H.map.Marker({lat:42.019796, lng:23.096027}),
      aubg = new H.map.Marker({lat:42.012749, lng:23.095317}),
      group = new H.map.Group();

  // add markers to the group
  group.addObjects([bachinovo, cityPark, aubg]);
  map.addObject(group);

  // get geo bounding box for the group and set it to the map
  map.getViewModel().setLookAtData({
    bounds: group.getBoundingBox()
  });
}

/**
 * Boilerplate map initialization code starts below:
 */

//Step 1: initialize communication with the platform
// In your own code, replace variable window.apikey with your own apikey
var platform = new H.service.Platform({
  apikey: 'niEJjvYdsERKxTANuhRpVyDchAf8QhBD6uuvGAYEA9M'
});
var defaultLayers = platform.createDefaultLayers();

//Step 2: initialize a map - this map is centered over Europe
// note that all the markers are in North America...
var map = new H.Map(document.getElementById('map'),
  defaultLayers.vector.normal.map,{
  center: {lat:50, lng:5},
  zoom: 4,
  pixelRatio: window.devicePixelRatio || 1
});
// add a resize listener to make sure that the map occupies the whole container
window.addEventListener('resize', () => map.getViewPort().resize());

//Step 3: make the map interactive
// MapEvents enables the event system
// Behavior implements default interactions for pan/zoom (also on mobile touch environments)
var behavior = new H.mapevents.Behavior(new H.mapevents.MapEvents(map));

// Now use the map as required...
addMarkersAndSetViewBounds(map);