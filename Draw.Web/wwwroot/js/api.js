import { readFiles } from './file.js';
import { addScrollEvent } from './nav.js';
import { readJsonFile } from './json.js';

var myElement = document.getElementById('mainData');
var myVariable = myElement.getAttribute('data-my-variable');
var mainData = JSON.parse(myVariable);

readFiles(mainData.MainTitles,'/files/api/html/','/files/api/json/')
addScrollEvent(mainData.MainTitles)

var elements= document.getElementsByClassName("copyBtnBox")

for (let i = 0; i < elements.length; i++) {
    const element = elements[i];
    element.addEventListener("click", function(){copyBtnClick(element)});
}

function copyBtnClick(btn){
    if(btn.id=="copyBtnBoxBody"){
        var jsonUrl=btn.parentElement.parentElement.children[0].children[0].id;
        readJsonFile('/files/api/json/'+jsonUrl).then(function(json){
            setTimeout(async()=>await window.navigator.clipboard.writeText(json), 100)
        })
        
    }
    if(btn.id=="copyBtnBoxHeader"){
        var text=btn.parentElement.parentElement.parentElement.children[1].children[0].children[0].children[0].innerText;
        setTimeout(async()=>await window.navigator.clipboard.writeText(text), 100)
    }
    
}

