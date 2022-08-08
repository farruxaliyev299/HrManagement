let replaceBtns = document.querySelectorAll('.day');

let defBtn = document.querySelector('.sign-mark-dash');

let trueBtn = document.querySelector('.sign-mark-check');


let falseBtn = document.querySelector('.sign-mark-cross');



replaceBtns.forEach(btn => {
    btn.firstElementChild.addEventListener('click', function(){
        if(this.classList.contains('sign-mark-dash')){
            this.classList.add('sign-mark-check');
            this.classList.remove('sign-mark-dash');
            this.innerHTML= trueBtn.innerHTML;
        }
        else if(this.classList.contains('sign-mark-check')){
            this.classList.add('sign-mark-cross');
            this.classList.remove('sign-mark-check');
            this.innerHTML = falseBtn.innerHTML;
        }
        else if(this.classList.contains('sign-mark-cross')){
            this.classList.add('sign-mark-dash');
            this.classList.remove('sign-mark-cross');
            this.innerHTML = defBtn.innerHTML;
        }
    })
        
})
