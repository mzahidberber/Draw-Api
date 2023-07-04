import { readFiles } from './file.js';
import { addScrollEvent } from './nav.js';

var myElement = document.getElementById('mainData');
var myVariable = myElement.getAttribute('data-my-variable');
var mainData = JSON.parse(myVariable);

readFiles(mainData.MainTitles,'/files/home/','/files/home/')
addScrollEvent(mainData.MainTitles)


