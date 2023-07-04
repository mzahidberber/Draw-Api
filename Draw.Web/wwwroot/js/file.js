import { writeJson } from './json.js';
import { writeText } from './txt.js';
export function readFiles(data, htmlUrl, jsonUrl) {
    for (let i = 0; i < data.length; i++) {
        const mt = data[i];
        if (mt.TextUrl1 != "" && mt.TextUrl1 != null) {
            writeText(htmlUrl+mt.TextUrl1, findPTagItem(mt.Title));
        };
        
        if (mt.Body != null) { writeJson(jsonUrl + mt.Body, document.getElementById(mt.Body)) };
        mt.BaseTitles.forEach((bt) => {
            if (bt.TextUrl1 != "" && bt.TextUrl1 != null) { writeText(htmlUrl + bt.TextUrl1, findPTagItem(bt.Title)); };
            if (bt.Body != null) { writeJson(jsonUrl + bt.Body, document.getElementById(bt.Body)) };
            bt.SubTitles.forEach((st) => {
                if (st.TextUrl1 != "" && st.TextUrl1 != null) { writeText(htmlUrl+st.TextUrl1, findPTagItem(st.Title)); };
                if (st.Body != null) { writeJson(jsonUrl + st.Body, document.getElementById(st.Body)) };
            })
        })
    }
}

function findPTagItem(itemId) {
    var anchorTags = document.getElementsByTagName("p");
    for (var i = 0; i < anchorTags.length; i++) {
        var anchor = anchorTags[i];
        var id = anchor.getAttribute("itemid");
        if (id == itemId) { return anchor; };
    }
}