//sidebar responsive
let toggleBtns = document.querySelectorAll('.navbar-toggler');
let sidebarClass = document.querySelector('.left-sidebar').classList;
let sections = document.querySelector('main').childNodes;
toggleBtns.forEach(btn => {
    btn.addEventListener('click', function(){
        if(sidebarClass.contains('swipe-out')){
            sidebarClass.remove('swipe-out');
            sections.forEach(section => {
                if(section.nodeName.toString() == 'SECTION'){
                    section.style = 
                    `margin-left: 260px`;
                }
            })
        }
        else{
            sidebarClass.add('swipe-out');
            sections.forEach(section => {
                if(section.nodeName.toString() == 'SECTION'){
                    section.style = 
                    `margin-left: 0px`;
                }
            })
        }
    })
})
//menu items background
let sbItems = document.querySelectorAll('.sb-item');
sbItems.forEach(item => {
    item.addEventListener("click" , function(){
        sbItems.forEach(item => {
            item.classList.remove('active');
        })

        if(this.classList.contains('active')){
            this.classList.remove('active');
        }
        else{
            this.classList.add('active');
        }
    })
});

//menu items show up
let sbTab = document.querySelectorAll('.sb-tab');
let hrMenu = document.querySelector('.hr-menu');
let prMenu = document.querySelector('.pr-menu');
sbTab.forEach(tab => {
    tab.addEventListener("click" , function(){
        if(this.classList.contains('hr-tab')){
            prMenu.classList.add('d-none');
            hrMenu.classList.remove('d-none');
        }
        else if(this.classList.contains('pr-tab')){
            hrMenu.classList.add('d-none');
            prMenu.classList.remove('d-none');
        }
    })
})