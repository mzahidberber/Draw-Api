
var toogleBtn = document.getElementById("toogleBtn");

toogleBtn.addEventListener("click", function () { toogle() });
var open = false;
var nav = document.getElementsByClassName("leftToggleNav")[0];
var navToggle = document.getElementById("toogleNav");
function toogle() {
    if (open) {
        navToggle.style.display = "none";
        open = false;
    }
    else {
        navToggle.innerHTML = nav.innerHTML;
        navToggle.style.display = "block";
        open = true;
    }

}