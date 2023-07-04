export function addRightNav(data,lastTitle){
    var navRight = document.getElementById('nav-right');
    navRight.innerHTML = builderRightNav(data,lastTitle);
}

function builderRightNav(data,lastTitle){
    var htmlContent = '';
    var baseTitleHtml = '';
    var subTitleHtml = '';
    data.forEach((mt) => {
        if (mt.Title == lastTitle) {
            mt.BaseTitles.forEach((bt) => {
                bt.SubTitles.forEach((st) => {subTitleHtml += builderNavItem(st.Title);})
                baseTitleHtml += builderTitle(builderNavItem(bt.Title),subTitleHtml)
                subTitleHtml = "";
            })
            htmlContent =builderNavList(builderNavItem(mt.Title),baseTitleHtml)
        };
    });
    return htmlContent;
}

function builderNavList(title,baseTitles){
    var item=
    `
    <div class="list-group list-group-light pt-5 dropdown-menu leftNav sticky-top">
        ${title}
        ${baseTitles}
    </div>
    `
    return item;
}

function builderTitle(title,subtitles){
    var item=
    `
        ${title}
        ${subtitles}
    `
    return item
}
function builderNavItem(title){
    var item=
    `
        <div class="m-0 p-0">
            <a href="#${title}" style="font-size:13px;" class="leftNavListItem leftNavSubTitle list-group-item list-group-item-dark p-1 ps-3 border-0 ripple">${title}</a>
        </div>
    `
    return item;
}