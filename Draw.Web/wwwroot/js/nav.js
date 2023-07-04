import { activeSelectDiv } from './leftNav.js';
import { addRightNav } from './rightNav.js';

var lastTitle = "";

export function addScrollEvent(data){
    document.addEventListener('scroll', function () {
        var currentDivIds = findVisibleDivs(document);
        currentDivIds.pop()
        if (currentDivIds[1] != undefined) {
            lastTitle = currentDivIds[1]
        }
        activeSelectDiv(currentDivIds)
        addRightNav(data,lastTitle)
    });
}




function findVisibleDivs(parentElement) {
    var visibleDivs = [];
    var childDivs = parentElement.querySelectorAll('div[id]');

    for (var i = 0; i < childDivs.length; i++) {
        var childDiv = childDivs[i];
        var rect = childDiv.getBoundingClientRect();

        if (rect.top <= 0 && rect.bottom >= 0) {
            visibleDivs.push(childDiv.id);
        }
    }

    return visibleDivs;
}