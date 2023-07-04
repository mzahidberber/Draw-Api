

export function writeText(url, tag) {
    readTextFile(url).then(function (text) {
        var lines = text.split("\n");
        for (var i = 0; i < lines.length; i++) {
            var line = lines[i];
            var regex = /^<h1/; 
            if (regex.test(line.substr(0, 1))) {
                var htmlObject = $(line);
                tag.innerHTML += htmlObject.innerHTML;
            }
        }
        tag.innerHTML += text;
    }).catch(function (error) { console.error(error); });

}


function readTextFile(url) {
    return new Promise(function (resolve, reject) {
        var rawFile = new XMLHttpRequest();
        rawFile.open("GET", url, true);
        rawFile.onreadystatechange = function () {
            if (rawFile.readyState === 4) {
                if (rawFile.status === 200) {
                    var text = rawFile.responseText;
                    resolve(text);
                } else {
                    reject(new Error(rawFile.status));
                }
            }
        };
        rawFile.send();
    });
}

