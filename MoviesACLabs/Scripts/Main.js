function test(){

    console.log("bbbb");
}

var imgss = [
    "https://static.pexels.com/photos/2855/landscape-mountains-nature-lake.jpg",
    "http://static.thousandwonders.net/Rocky.Mountain.National.Park.original.3521.jpg",
    "http://phandroid.s3.amazonaws.com/wp-content/uploads/2014/10/mountains_hd.jpg",
    "http://k36.kn3.net/taringa/4/5/A/5/9/1/gonzaa9614/396.jpg",
    "http://www.visitnc.com/contents/imgcrop/35625/800/448"

    
];

var prevb = document.getElementById('b1');
var nextb = document.getElementById('b2');

var next = 0;
var prev=0;

nextb.addEventListener('click', function () {
   
    next++;

     if (next == 5) {
           next = 0;
        }

     document.getElementById("imgs").src = imgss[next];
    
    
    
});

prevb.addEventListener('click', function () {


    prev = --next;
    if (prev < 0) {
        prev = 0;
   

    }
    
    document.getElementById("imgs").src = imgss[prev];
    }
});