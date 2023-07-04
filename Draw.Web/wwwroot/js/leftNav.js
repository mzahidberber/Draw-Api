


export function activeSelectDiv(currentDivIds){
    var anchorTags = document.getElementsByTagName("a");
    for (var i = 0; i < anchorTags.length; i++) {
        var anchor = anchorTags[i];
        if (anchor.classList.contains("activeATag")) {
            anchor.classList.remove("activeATag");
        }
        var href = anchor.getAttribute("href");
        if (href == "#" + currentDivIds[currentDivIds.length - 1]) {
            anchor.classList.add("activeATag");
        }
    }
}




